using Nmkr.Sdk;
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
    public class StorefrontViewController : ViewController
    {
        private VisualTreeAsset _cardTemplate = null;
        private VisualElement _cardGridContainer = null;
        private VisualElement _displayContainer = null;
        private Label _displayText = null;

        public StorefrontViewController(VisualElement root, StorefrontItemData[] storefrontItems, VisualTreeAsset storefrontCardTemplate) : base(root)
        {
            _cardTemplate = storefrontCardTemplate;
            _cardGridContainer = root.Q<VisualElement>("CardGridContainer");
            _displayContainer = root.Q<VisualElement>("DisplayContainer");
            _displayText = root.Q<Label>("DisplayText");

            SpawnStorefrontCards(storefrontItems);
        }

        private void SpawnStorefrontCards(StorefrontItemData[] storefrontItems)
        {
            for (int i = 0; i < storefrontItems.Length; i++)
            {
                CreateCard(storefrontItems[i]);
            }
        }

        private void CreateCard(StorefrontItemData item)
        {
            TemplateContainer cardContainer = _cardTemplate.Instantiate();
            StorefrontItemCard card = new StorefrontItemCard(cardContainer, item);
            _cardGridContainer.Add(cardContainer);
            card.onPurchaseButtonClicked += () => OnPurchaseClicked(card, item);
        }

        private async void OnPurchaseClicked(StorefrontItemCard card, StorefrontItemData item)
        {
            card.EnablePurchaseButton(false);
            var response = await SDKClient.PurchaseAndMint(item.ProjectUid, ClientAccount.ManagedWalletAddress, ClientAccount.ManagedWalletPassword, item.PriceInLovelace, item.NftCount);
            if (response.success)
            {
                DisplayMessage($"Purchase Success! Bought ({response.result.nfts.Length}) Nfts");
            }
            else
            {
                DisplayError($"Purchase Failed. {response.error.message}");
            }
            card.EnablePurchaseButton(true);
        }

        private void DisplayMessage(string message)
        {
            _displayContainer.style.display = DisplayStyle.Flex;
            _displayText.text = message;
            _displayText.style.color = Color.green;
            SetMessageTimer();
        }

        private void DisplayError(string errorMessage)
        {
            _displayContainer.style.display = DisplayStyle.Flex;
            _displayText.text = errorMessage;
            _displayText.style.color = Color.red;
            SetMessageTimer();
        }

        private async void SetMessageTimer()
        {
            await Task.Delay(5000);
            _displayContainer.style.display = DisplayStyle.None;
            _displayText.text = "";
        }
    }
}