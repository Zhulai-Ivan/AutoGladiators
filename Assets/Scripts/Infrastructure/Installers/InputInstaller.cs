using Infrastructure.InputSystem;
using Lobby;
using Zenject;

namespace Infrastructure.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputService>().AsSingle().NonLazy();
            Container.Bind<LobbyInputHandler>().AsSingle().NonLazy();
        }
    }
}