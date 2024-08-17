using Fusion;

namespace System.GameCycle
{
    public interface IPlayerLeaveable : IGameListener
    {
        void OnPlayerLeft(PlayerRef playerRef);
    }
}