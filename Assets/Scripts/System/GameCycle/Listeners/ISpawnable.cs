using Fusion;

namespace System.GameCycle
{
    public interface ISpawnable : IGameListener
    {
        void OnSpawned(NetworkRunner runner, NetworkObject networkObject);
    }
}