using Infrastructure.CommandSystem;
using UI.Console;
using Zenject;

namespace Infrastructure.Installers
{
    public class ConsoleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CommandRegistry>().AsSingle();
            Container.Bind<CommandConsoleModel>().AsSingle();
            Container.Bind<ConsoleViewModel>().AsSingle();
        }
    }
}