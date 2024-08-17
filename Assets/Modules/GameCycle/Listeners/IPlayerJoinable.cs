using Fusion;

namespace System.GameCycle
{
    public interface IPlayerJoinable : IGameListener
    {
        void OnPlayerJoined(PlayerRef playerRef);
    }
}