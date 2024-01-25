using System;
using UnityEngine.UIElements;

namespace Nmkr.Demo
{
    public class ViewController
    {
        protected VisualElement _root = null;

        public Action onDisplayed = null;

        public VisualElement Root => _root;

        public ViewController(VisualElement root)
        {
            _root = root;
        }

        public void Display(bool enabled)
        {
            if (_root == null) { return; }
            _root.style.display = enabled ? DisplayStyle.Flex : DisplayStyle.None;
            if (enabled)
            {
                onDisplayed?.Invoke();
            }
        }
    }
}