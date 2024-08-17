using Game.GameEngine.Entities;
using UnityEngine;

namespace Game.GameEngine.PlayerContext
{
    public sealed class UnitCommander : IUnitCommander
    {
        private readonly UnitStack _unitStack;

        public UnitCommander(UnitStack unitStack)
        {
            _unitStack = unitStack;
        }

        public void MoveToPosition(Vector3 targetPosition)
        {
            foreach (GameObject unit in _unitStack)
            {
                unit.GetComponent<MovementAgent>().SetDestination(targetPosition);
            }
        }
    }
}