using Core.Base;
using TMPro;
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

        protected override void OnDisable()
        {
            base.OnDisable();
            UnSubscribe();
        }

        private void UnSubscribe()
        {
            _commandInput.onSubmit.RemoveListener(OnSubmit);
        }
    }
}