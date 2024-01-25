using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Nmkr.Demo
{
    public class UIManager : MonoBehaviour
    {
        private AccountLoginViewController _accountLoginView = null;
        private AccountCreateViewController _accountCreateView = null;
        private NftHubViewController _nftHubView = null;
        private List<ViewController> _viewControllers = new List<ViewController>();
        [Space]
        [Header("Storefront")]
        [SerializeField] private StorefrontItemData[] _storefrontItems = null;
        [SerializeField] private VisualTreeAsset _storefrontCardTemplate = null;
        [Space]
        [Header("Inventory")]
        [SerializeField] private VisualTreeAsset _inventoryCardTemplate = null;


        private void Start()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _accountLoginView = new AccountLoginViewController(root.Q("AccountLoginView"));
            _accountCreateView = new AccountCreateViewController(root.Q("AccountCreateView"));
            _nftHubView = new NftHubViewController(root.Q("NftHubView"), _storefrontItems, _storefrontCardTemplate, _inventoryCardTemplate);

            _viewControllers.Add(_accountCreateView);
            _viewControllers.Add(_accountLoginView);
            _viewControllers.Add(_nftHubView);

            Display(_accountLoginView);

            _accountLoginView.onNavAccountCreateViewClicked = () =>
            {
                Display(_accountCreateView);
            };

            _accountCreateView.onNavAccountLoginViewClicked = () =>
            {
                Display(_accountLoginView);
            };

            _accountCreateView.onLoginSuccessful = () =>
            {
                Display(_nftHubView);
            };

            _accountLoginView.onLoginSuccessful = () =>
            {
                Display(_nftHubView);
            };
        }

        private void Display(ViewController viewController)
        {
            for (int i = 0; i < _viewControllers.Count; i++)
            {
                _viewControllers[i].Display(false);
            }

            viewController.Display(true);
        }
    }
}