using UnityEngine;
using Zenject;

namespace Game.GameEngine.GameContext
{
    public sealed class CameraInstaller : Installer<CameraInstaller>
    {
        private const float MOVEMENT_SPEED = 5;

        public override void InstallBindings()
        {
            Camera camera = Camera.main;
            this.Container.Bind<Camera>().FromInstance(camera).AsSingle();
            this.Container.BindInterfacesTo<CameraMover>().AsCached().WithArguments(camera!.transform, MOVEMENT_SPEED);
            this.Container.Bind<CameraInput>().AsSingle().NonLazy();
        }
    }
}