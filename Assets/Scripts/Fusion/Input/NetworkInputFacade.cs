using UnityEngine;

namespace Fusion.Input
{
    public sealed class NetworkInputFacade : MonoBehaviour
    {
        public Vector3 MoveDirection { get; private set; }
        public bool IsFire { get; private set; }
        
        public void SetInput(NetworkInputData inputData)
        {
            MoveDirection = inputData.MoveDirection;
            IsFire = inputData.IsSpaceDown;
        }
    }
}