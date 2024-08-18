using Game.GameEngine.Entities;
using UnityEngine;

namespace Game.GameEngine.PlayerContext
{
    [RequireComponent(typeof(UnitStack))]
    public sealed class UnitCommander : MonoBehaviour
    {
        private UnitStack _unitStack;

        private void Awake()
        {
            _unitStack = this.GetComponent<UnitStack>();
        }

        public void MoveToPosition(Vector3 targetPosition)
        {
            foreach (GameObject unit in _unitStack.GetUnits())
            {
                unit.GetComponent<MovementAgent>().SetDestination(targetPosition);
            }
        }
    }
}
