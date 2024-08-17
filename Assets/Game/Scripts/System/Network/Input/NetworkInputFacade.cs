using UnityEngine;

namespace System.Network.Input
{
    public sealed class NetworkInputFacade
    {
        public Vector3 MoveDirection { get; private set; }
        public Vector3 MousePosition { get; private set; }
        public bool IsFormationStart { get; private set; }
        
        internal void ReceiveInput(NetworkInputData inputData)
        {
            MoveDirection = inputData.MoveDirection;
            MousePosition = inputData.MousePosition;
            IsFormationStart = inputData.IsM0;
        }
    }
}