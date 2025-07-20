using Core.Base;
using Infrastructure.CommandSystem;
using UniRx;
using UnityEngine;

namespace UI.Console
{
    public class ConsoleViewModel : BaseViewModel
    {
        private CommandConsoleModel _consoleModel;
        
        public ReactiveProperty<bool> IsActive { get; } = new ReactiveProperty<bool>();
        
        public ConsoleViewModel(CommandConsoleModel consoleModel)
        {
            _consoleModel = consoleModel;
            Application.logMessageReceived += OnLogMessageReceived;
        }

        private void OnLogMessageReceived(string condition, string stackTrace, LogType type)
        {
            SendMessage(condition);
        }

        public void Submit(string input)
        {
            string result = _consoleModel.ExecuteCommand(input);
            SendMessage(result);
        }

        public void ToggleConsole() => 
            IsActive.Value = !IsActive.Value;

        public override void Dispose()
        {
            Application.logMessageReceived -= OnLogMessageReceived;
        }
    }
}