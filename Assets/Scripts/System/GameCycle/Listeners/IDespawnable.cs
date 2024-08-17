using Fusion;

namespace System.GameCycle
{
    public interface IDespawnable : IGameListener
    {
        void OnDespawned(NetworkRunner runner, NetworkObject networkObject);
    }
}