using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public class UnityButton : MonoBehaviour
    {
        private IButton _button;
        private Button _unityButton;

        public void Subscribe(IButton button)
        {
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _unityButton = GetComponent<Button>();
            _unityButton.onClick.AddListener(_button.Press);
        }

        private void OnDestroy()
        {
            if (_unityButton != null)
                _unityButton.onClick.RemoveListener(_button.Press);
        }
    }
}