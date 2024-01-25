using Nmkr.Sdk;
using Nmkr.Sdk.Schemas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;  // Download the 'com.unity.services.authentication@3.2.0' package
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UIElements;
using static Nmkr.Sdk.Api;

namespace Nmkr.Demo
{
    public class AccountCreateViewController : ViewController
    {
        private TextField _usernameField = null;
        private TextField _passwordField = null;
        private Button _createAccountButton = null;
        private Button _navAccountLoginViewButton = null;
        private Label _errorText = null;

        public Action onNavAccountLoginViewClicked { set => _navAccountLoginViewButton.clicked += value; }
        public Action onLoginSuccessful = null;

        public AccountCreateViewController(VisualElement root) : base(root)
        {
            _usernameField = root.Q<TextField>("UsernameField");
            _passwordField = root.Q<TextField>("PasswordField");
            _createAccountButton = root.Q<Button>("CreateAccountButton");
            _navAccountLoginViewButton = root.Q<Button>("NavLoginAccountButton");
            _errorText = root.Q<Label>("ErrorText");

            _createAccountButton.clicked += () =>
            {
                CreateAcount();
            };

            onDisplayed += OnDisplayed;

            SetupEvents();
        }

        private void OnDisplayed()
        {
            _errorText.text = string.Empty;
        }

        private async void CreateAcount()
        {
            string username = _usernameField.text;
            string password = _passwordField.text;
            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await SignUpWithUsernamePassword(username, password);
            }
            // for simplicity of the demo, wallet password would be generated with the player's id.
            // This is not best practice
            string walletPassword = AuthenticationService.Instance.PlayerId;
            bool walletCreated = await CreateWallet(username, walletPassword);

            if (AuthenticationService.Instance.IsSignedIn && walletCreated)
            {
                onLoginSuccessful?.Invoke();
            }
        }

        private async Task<bool> CreateWallet(string walletName, string walletPassword)
        {
            var walletResponse = await SDKClient.CreateWallet(walletName, walletPassword);
            if (walletResponse.success)
            {
                WalletInfo wallet = walletResponse.result;
                await CloudSaveClient.Save("ManagedWalletAddress", wallet.address);
                return true;
            }
            else
            {
                _errorText.text = "Wallet Creation Failed.";
                return false;
            }
        }

        private async Task SignUpWithUsernamePassword(string username, string password)
        {
            try
            {
                await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
                Debug.Log("SignUp is successful.");
            }
            catch (AuthenticationException ex)
            {
                // Compare error code to AuthenticationErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
                _errorText.text = ex.Message;
            }
            catch (RequestFailedException ex)
            {
                // Compare error code to CommonErrorCodes
                // Notify the player with the proper error message
                Debug.LogException(ex);
                _errorText.text = ex.Message;
            }
            catch(Exception ex)
            {
                Debug.LogException(ex);
                _errorText.text = ex.Message;
            }
        }

        private void SetupEvents()
        {
            AuthenticationService.Instance.SignedIn += () => {
                Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
                Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");
            };

            AuthenticationService.Instance.SignInFailed += (err) => {
                Debug.LogError(err);
                _errorText.text = err.Message;
            };

            AuthenticationService.Instance.SignedOut += () => {
                Debug.Log("Player signed out.");
            };

            AuthenticationService.Instance.Expired += () =>
            {
                Debug.Log("Player session could not be refreshed and expired.");
            };
        }
    }
}