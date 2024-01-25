using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Nmkr.Demo
{
    public class StorefrontItemCard : ViewController
    {
        private VisualElement _image = null;
        private Label _itemTitle = null;
        private Label _priceLabel = null;
        private Button _purchaseButton = null;

        public Action onPurchaseButtonClicked = null;

        public StorefrontItemCard(VisualElement root, StorefrontItemData itemInfo) : base(root)
        {
            _image = root.Q<VisualElement>("ItemImage");
            _itemTitle = root.Q<Label>("ItemTitle");
            _priceLabel = root.Q<Label>("PriceLabel");
            _purchaseButton = root.Q<Button>("PurchaseButton");

            _purchaseButton.clicked += () =>
            {
                Debug.Log($"Purchase {itemInfo.ItemName}");
                onPurchaseButtonClicked?.Invoke();
            };

            _itemTitle.text = itemInfo.ItemName;
            _priceLabel.text = $"Price: {ConvertLovelace(itemInfo.PriceInLovelace)} ADA";
            _image.style.backgroundImage = new StyleBackground(itemInfo.ItemImage);
        }

        private string ConvertLovelace(long lovelaceAmount)
        {
            int ada = (int)(lovelaceAmount / 1000000);
            int adaParts = (int)(lovelaceAmount % 1000000);
            return $"<size=14>{ada}</size>.<size=10>{adaParts}</size>";
        }

        public void EnablePurchaseButton(bool enable)
        {
            _purchaseButton.SetEnabled(enable);
        }
    }
}
