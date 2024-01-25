using Nmkr.Sdk.Schemas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Nmkr.Demo
{
    public class InventoryViewController : ViewController
    {
        private VisualTreeAsset _cardTemplate = null;
        private ScrollView _cardGridContainer = null;
        private VisualElement _displayContainer = null;
        private Label _displayText = null;

        private VisualElement _sendPopupContainer = null;
        private Label _sendHeader = null;
        private Button _sendButton = null;
        private Button _sendCancelButton = null;
        private Label _sendErrorText = null;
        private TextField _sendAddressInputField = null;
        public Action onSendClicked = null;
        public Action onCancelClicked = null;

        public List<InventoryItemCard> _inventoryCards = new List<InventoryItemCard>();

        public InventoryViewController(VisualElement root, VisualTreeAsset inventoryCardTemplate) : base(root)
        {
            _cardTemplate = inventoryCardTemplate;
            _cardGridContainer = root.Q<ScrollView>("CardGridContainer");
            _displayContainer = root.Q<VisualElement>("DisplayContainer");
            _displayText = root.Q<Label>("DisplayText");
            _cardGridContainer.contentContainer.style.flexDirection = FlexDirection.Row;
            _cardGridContainer.contentContainer.style.flexWrap = Wrap.Wrap;
            
            _sendPopupContainer = root.Q<VisualElement>("SendPopupContainer");
            _sendHeader = _sendPopupContainer.Q<Label>("SendHeader");
            _sendButton = _sendPopupContainer.Q<Button>("SendButton");
            _sendCancelButton = _sendPopupContainer.Q<Button>("CancelButton");
            _sendAddressInputField = _sendPopupContainer.Q<TextField>("SendAddressInputField");
            _sendErrorText = _sendPopupContainer.Q<Label>("ErrorText");
            
            _sendPopupContainer.style.display = DisplayStyle.None;

            _sendButton.clicked += () =>
            {
                onSendClicked?.Invoke();
            };

            _sendCancelButton.clicked += () =>
            {
                _sendPopupContainer.style.display = DisplayStyle.None;
                onCancelClicked?.Invoke();
            };
        }

        public void LoadTokenCards(TxInTokensClass[] tokens)
        {
            for (int i = 0; i < _inventoryCards.Count; i++)
            {
                _cardGridContainer.Remove(_inventoryCards[i].Root);

                Debug.Log($"Remove {_inventoryCards[i].ItemInfo.name}");
            }

            _inventoryCards.Clear();

            for (int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                var info = new InventoryItemInfo()
                {
                    name = token.tokenname,
                    policyId = token.policyId,
                    assetNameInHex = token.tokennameHex,
                    quantity = token.quantity
                };
                var card = CreateCard(info);
                _inventoryCards.Add(card);
            }
        }

        private InventoryItemCard CreateCard(InventoryItemInfo itemInfo)
        {
            TemplateContainer cardContainer = _cardTemplate.Instantiate();
            InventoryItemCard card = new InventoryItemCard(cardContainer, itemInfo);
            _cardGridContainer.Add(cardContainer);
            card.onSendButtonClicked += () => OnCardSendClicked(card, itemInfo);
            return card;
        }

        private void OnCardSendClicked(InventoryItemCard card, InventoryItemInfo itemInfo)
        {
            card.EnableButton(false);
            _sendPopupContainer.style.display = DisplayStyle.Flex;

            _sendHeader.text = $"Sending out token named \"{itemInfo.name}\" to:";

            onSendClicked = null;
            onSendClicked += () =>
            {
                OnSendConfirmationButtonClicked(card, itemInfo);
            };

            onCancelClicked?.Invoke(); // to cancel previous send attempt
            onCancelClicked = null;
            onCancelClicked += () =>
            {
                card.EnableButton(true);
            };
        }


        private async void OnSendConfirmationButtonClicked(InventoryItemCard card, InventoryItemInfo itemInfo)
        {
            Debug.Log($"Attempt send {itemInfo.name}");
            _sendButton.SetEnabled(false);

            string receiverAddress = _sendAddressInputField.text;
            var token = new TransactionTokensClass()
            {
                policyId = itemInfo.policyId,
                assetNameInHex = itemInfo.assetNameInHex,
                quantity = itemInfo.quantity,
            };
            var transactionResponse = await SDKClient.MakeManagedWalletTransaction(ClientAccount.ManagedWalletAddress, ClientAccount.ManagedWalletPassword, receiverAddress, token);
            if (transactionResponse.success)
            {
                _sendPopupContainer.style.display = DisplayStyle.None;
                card.Root.SetEnabled(false);
                DisplayMessage($"Send Success! Sent {itemInfo.name}");
            }
            else
            {
                DisplayError($"Purchase Failed. {transactionResponse.error.message}");
            }
            _sendButton.SetEnabled(true);
            card.EnableButton(true);
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