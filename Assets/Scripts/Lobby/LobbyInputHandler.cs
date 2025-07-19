using Infrastructure.InputSystem;
using UI.Console;
using UnityEngine.InputSystem;

namespace Lobby
{
    public class LobbyInputHandler
    {
        private readonly InputService _inputService;
        private readonly ConsoleViewModel _consoleViewModel;

        public LobbyInputHandler(InputService inputService, ConsoleViewModel consoleViewModel)
        {
            _inputService = inputService;
            _consoleViewModel = consoleViewModel;

            _inputService.EnableLobby();
            _inputService.Controls.Lobby.ToggleConsole.performed += OnToggleConsolePerformed;
        }

        private void OnToggleConsolePerformed(InputAction.CallbackContext _)
        {
            _consoleViewModel.ToggleConsole();
        }
    }
}