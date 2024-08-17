using Fusion;

namespace System.GameCycle
{
    public interface IRenderable : IGameListener
    {
        void OnRender(NetworkRunner runner, NetworkObject networkObject);
    }
}