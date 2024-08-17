using System.Network.Spawn;
using Fusion;
using UnityEngine;
using Zenject;

namespace System.Network
{
    internal sealed class NetworkInstaller : MonoInstaller
    {
        [SerializeField]
        private NetworkRunner _runner;
        
        [SerializeField]
        private NetworkPrefabRef _playerPrefab;
        
        [SerializeField]
        private Vector3 _spawnPosition;
        
        [SerializeField]
        private Vector3 _spawnRotation;
        
        public override void InstallBindings()
        {
            BindNetworkRunner();
            BindPlayerFactory();
            BindPlayerSpawner();
        }

        private void BindNetworkRunner()
        {
            Container.Bind<NetworkRunner>().FromInstance(_runner).AsSingle();
        }
        
        private void BindPlayerFactory()
        {
            Container.Bind<Common.Creation.IFactory<NetworkObject, PlayerRef>>().To<PlayerFactory>()
                .AsSingle().WithArguments(_playerPrefab, _spawnPosition, _spawnRotation);
        }

        private void BindPlayerSpawner()
        {
            Container.BindInterfacesTo<PlayerSpawner>().AsCached();
        }
    }
}