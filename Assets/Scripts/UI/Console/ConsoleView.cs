using System;
using Core.Base;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Console
{
    public class ConsoleView : BaseView<ConsoleViewModel>
    {
        [Header("Ui elements")] 
        [SerializeField] private TMP_InputField _commandInput;
        [SerializeField] private TMP_Text _logText;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private Button _closeButton;
         
        protected override void Initialize()
        {
            base.Initialize();
            
            ViewModel.IsActive.Subscribe(SetConsoleActive).AddTo(this);
            _closeButton.onClick.AddListener(() => ViewModel.IsActive.Value = false);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            Subscribe();
        }
        

        private void Subscribe()
        {
            _commandInput.onSubmit.AddListener(OnSubmit);
            _commandInput.ActivateInputField();
        }

        private void OnSubmit(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return;

            ViewModel.Submit(input);

            _commandInput.text = string.Empty;
            _commandInput.ActivateInputField();
        }

        protected override void OnMessageReceived(string message)
        {
            _logText.text += message + "\n";

            Canvas.ForceUpdateCanvases();
            _scrollRect.verticalNormalizedPosition = 0;
        }

        private void SetConsoleActive(bool active) => 
            gameObject.SetActive(active);

        protected override void OnDisable()
        {
            base.OnDisable();
            UnSubscribe();
        }

        private void UnSubscribe()
        {
            _commandInput.onSubmit.RemoveListener(OnSubmit);
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}