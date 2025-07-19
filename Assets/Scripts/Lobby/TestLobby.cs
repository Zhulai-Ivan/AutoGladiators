using Core.Attributes;
using UI.Console;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using UnityEngine;
using Zenject;

namespace Lobby
{
    public class TestLobby : MonoBehaviour
    {
        private ConsoleViewModel _consoleViewModel;

        [Inject]
        public void Construct(ConsoleViewModel consoleModel)
        {
            _consoleViewModel = consoleModel;
        }
    
        private async void Start()
        {
            await UnityServices.InitializeAsync();

            AuthenticationService.Instance.SignedIn += () =>
            {
                Debug.Log($"Signed in {AuthenticationService.Instance.PlayerId}");
            };

            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    
        // using in console commands
        [Command]
        private async void CreateLobby()
        {
            try
            {
                string lobbyName = "MyLobby";
                int maxPlayers = 4;
                Unity.Services.Lobbies.Models.Lobby lobby =
                    await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers);

                _consoleViewModel.SendMessage($"Lobby created: {lobby.Name} | {lobby.MaxPlayers}");
            }
            catch (LobbyServiceException exception)
            {
                _consoleViewModel.SendMessage($"Can not create lobby: {exception.Message}");
            }

        }

        private async void LobbiesList()
        {
            var queryResponse = await Lobbies.Instance.QueryLobbiesAsync();
            
            
        }
    }
}
