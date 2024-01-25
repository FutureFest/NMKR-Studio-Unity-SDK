using UnityEngine;

namespace Nmkr.Demo
{
    [CreateAssetMenu(fileName = "StorefrontItemData", menuName = "Nmkr/StorefrontItemData")]
    public class StorefrontItemData : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private long _priceInLovelace;
        [SerializeField] private string _projectUid;
        [SerializeField] private int _nftCount = 1;
        [SerializeField] private Texture2D _itemImage;

        public string ItemName => _itemName;
        public long PriceInLovelace => _priceInLovelace;
        public string ProjectUid => _projectUid;
        public int NftCount => _nftCount;
        public Texture2D ItemImage => _itemImage;
    }
}