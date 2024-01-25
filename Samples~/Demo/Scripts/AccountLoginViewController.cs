using Nmkr.Sdk;
using Nmkr.Sdk.Schemas;
using System;
using System.Linq;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Nmkr.Demo
{
    public class AccountLoginViewController : ViewController
    {
        private TextField _usernameField = null;
        private TextField _passwordField = null;
        private Button _loginAccountButton = null;
        private Button _navAccountCreateViewButton = null;
        private Label _errorText = null;

        public Action onNavAccountCreateViewClicked { set => _navAccountCreateViewButton.clicked += value; }
        public Action onLoginSuccessful = null;

        public AccountLoginViewController(VisualElement root) : base(root)
        {
            _usernameField = root.Q<TextField>("UsernameField");
            _passwordField = root.Q<TextField>("PasswordField");
            _loginAccountButton = root.Q<Button>("LoginAccountButton");
            _navAccountCreateViewButton = root.Q<Button>("NavCreateAccountButton");
            _errorText = root.Q<Label>("ErrorText");

            _loginAccountButton.clicked += () =>
            {
                Login();
            };

            onDisplayed += OnDisplayed;
            SetupEvents();
            if (PlayerPrefs.HasKey("LastUsername"))
            {
                _usernameField.value = PlayerPrefs.GetString("LastUsername");
            }
            if (PlayerPrefs.HasKey("LastPassword"))
            {
                _passwordField.value = PlayerPrefs.GetString("LastPassword");
            }
        }

        private void OnDisplayed()
        {
            _errorText.text= string.Empty;
        }

        private async void Login()
        {
            string username = _usernameField.text;
            string password = _passwordField.text;
            await SignInWithUsernamePasswordAsync(username, password);

            var address = await CloudSaveClient.Load<string>("ManagedWalletAddress");

            if (AuthenticationService.Instance.IsSignedIn && !string.IsNullOrEmpty(address))
            {
                if (!string.IsNullOrEmpty(address))
                {
                    ClientAccount.SetManagedWalletAddress(address);
                    onLoginSuccessful?.Invoke();
                    PlayerPrefs.SetString("LastUsername", username);
                    PlayerPrefs.SetString("LastPassword", password);
                }
                else
                {
                    _errorText.text = "Wallet not found.";
                }
            }
        }

        private async Task SignInWithUsernamePasswordAsync(string username, string password)
        {
            try
            {
                await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
                Debug.Log("SignIn is successful.");
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