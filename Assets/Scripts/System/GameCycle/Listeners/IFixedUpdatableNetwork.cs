using Fusion;

namespace System.GameCycle
{
    public interface IFixedUpdatableNetwork : IGameListener
    {
        void OnFixedUpdateNetwork(NetworkRunner runner, NetworkObject networkObject);
    }
}