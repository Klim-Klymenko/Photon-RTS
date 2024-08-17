using Zenject;

namespace Game.GameEngine.GameContext
{
    public sealed class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            this.Container.Bind<PlayerProvider>().AsSingle().NonLazy();
        }
    }
}