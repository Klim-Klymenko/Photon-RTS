using UnityEngine;

namespace Game.GameEngine.PlayerContext
{
    public interface IUnitCommander
    {
        void MoveToPosition(Vector3 targetPosition);
    }
}