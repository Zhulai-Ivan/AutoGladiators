using Core.Base;
using Infrastructure.CommandSystem;

namespace UI.Console
{
    public class ConsoleViewModel : BaseViewModel
    {
        private CommandConsoleModel _consoleModel;
        
        public ConsoleViewModel(CommandConsoleModel consoleModel)
        {
            _consoleModel = consoleModel;
        }

        public void Submit(string input)
        {
            string result = _consoleModel.ExecuteCommand(input);
            SendMessage(result);
        }
    }
}