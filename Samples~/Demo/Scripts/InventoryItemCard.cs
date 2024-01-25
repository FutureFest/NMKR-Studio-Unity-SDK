using Nmkr.Sdk.Schemas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Nmkr.Demo
{
    public class InventoryItemCard : ViewController
    {
        private VisualElement _image = null;
        private Label _itemTitle = null;

        private Button _sendButton = null;

        public Action onSendButtonClicked = null;

        private InventoryItemInfo _itemInfo;
        public InventoryItemInfo ItemInfo => _itemInfo;

        public InventoryItemCard(VisualElement root, InventoryItemInfo itemInfo) : base(root)
        {
            _itemInfo = itemInfo;
            _image = root.Q<VisualElement>("ItemImage");
            _itemTitle = root.Q<Label>("ItemTitle");

            _sendButton = root.Q<Button>("SendButton");

            _sendButton.clicked += () =>
            {
                onSendButtonClicked?.Invoke();
            };

            _itemTitle.text = itemInfo.name;
        }

        public void EnableButton(bool enable)
        {
            _sendButton.SetEnabled(enable);
        }
    }

    public struct InventoryItemInfo
    {
        public string name;
        //public Image image;
        public string policyId;
        public string assetNameInHex;
        public long quantity;
    }
}
