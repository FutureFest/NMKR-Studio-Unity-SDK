using Nmkr.Sdk.Schemas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using static Nmkr.Sdk.Api;

namespace Nmkr.Demo
{
    public class NftHubViewController : ViewController
    {
        private Button _storefrontTabButton = null;
        private Button _inventoryTabButton = null;
        private List<Button> _tabButtons = new List<Button>();
        private Label _adaAmount = null;
        private Button _copyButton = null;
        private Label _addressLabel = null;

        private string _selectedTabUssClass = "Button-Header-Selected";

        private StorefrontViewController _storefrontGridView = null;
        private InventoryViewController _inventoryGridView = null;


        private List<ViewController> _gridViews = new List<ViewController>();

        public NftHubViewController(VisualElement root, StorefrontItemData[] storefrontItems, VisualTreeAsset storefrontCardTemplate, VisualTreeAsset inventoryCardTemplate) : base(root)
        {
            _storefrontTabButton = root.Q<Button>("StorefrontTabButton");
            _inventoryTabButton = root.Q<Button>("InventoryTabButton");
            _adaAmount = root.Q<Label>("AdaAmount");
            _copyButton = root.Q<Button>("CopyButton");
            _addressLabel = root.Q<Label>("AddressLabel");
            
            _tabButtons.Add(_storefrontTabButton);
            _tabButtons.Add(_inventoryTabButton);

            _storefrontGridView = new StorefrontViewController(root.Q("StorefrontGridView"), storefrontItems, storefrontCardTemplate);
            _inventoryGridView = new InventoryViewController(root.Q("InventoryGridView"), inventoryCardTemplate);

            _gridViews.Add(_storefrontGridView);
            _gridViews.Add(_inventoryGridView);

            SelectTab(_storefrontTabButton);
            DisplayView(_storefrontGridView);

            _storefrontTabButton.clicked += () =>
            {
                SelectTab(_storefrontTabButton);
                DisplayView(_storefrontGridView);
            };

            _inventoryTabButton.clicked += () =>
            {
                SelectTab(_inventoryTabButton);
                DisplayView(_inventoryGridView);
                UpdateWalletAssets();

            };

            _copyButton.clicked += () =>
            {
                GUIUtility.systemCopyBuffer = ClientAccount.ManagedWalletAddress;
                _copyButton.text = "Copied";
            };

            onDisplayed += OnDisplay;
        }

        private async void OnDisplay()
        {
            _addressLabel.text = ClientAccount.ManagedWalletAddress;
            _copyButton.text = "Copy";
            _adaAmount.text = await GetWalletAmount();
        }

        private async Task<string> GetWalletAmount()
        {
            ApiResponse<TxInAddressesClass> response = await SDKClient.GetWalletUtxo(ClientAccount.ManagedWalletAddress);
            if (response.success)
            {
                TxInAddressesClass walletUtxo = response.result;
                int ada = (int)(walletUtxo.lovelaceSummary / 1000000);
                int adaParts = (int)(walletUtxo.lovelaceSummary % 1000000);
                return $"<size=14>{ada}</size>.<size=10>{adaParts}</size>";
            }
            else
            {
                return "-";
            }
        }

        private async void UpdateWalletAssets()
        {
            ApiResponse<WalletAssets> response = await SDKClient.GetWalletAssets(ClientAccount.ManagedWalletAddress);
            if (response.success)
            {
                WalletAssets assets = response.result;
                _adaAmount.text = $"<size=14>{assets.adaAmount}</size>.<size=10>{assets.lovelaceAmount}</size>";
                _inventoryGridView.LoadTokenCards(assets.tokens);
            }
            else
            {
                _adaAmount.text = "-";
            }
        }

        private void SelectTab(Button tabButton)
        {
            for (int i = 0; i < _tabButtons.Count; i++)
            {
                _tabButtons[i].RemoveFromClassList(_selectedTabUssClass);
            }

            tabButton.AddToClassList(_selectedTabUssClass);
        }

        private void DisplayView(ViewController viewController)
        {
            for (int i = 0; i < _gridViews.Count; i++)
            {
                _gridViews[i].Display(false);
            }

            viewController.Display(true);
        }
    }
}
