using System.GameCycle;
using Fusion;
using UnityEngine;

namespace GameEngine.Entities.Switching
{
    internal sealed class SwitchingComponent : ISpawnable
    {
        private readonly GameObject _gameObject;

        internal SwitchingComponent(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        void ISpawnable.OnSpawned(NetworkRunner runner, NetworkObject networkObject)
        {
            _gameObject.SetActive(networkObject.HasInputAuthority);
        }
    }
}