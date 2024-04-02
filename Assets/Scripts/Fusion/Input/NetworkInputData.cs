using UnityEngine;
using UnityEngine.Serialization;

namespace Fusion.Input
{
    public struct NetworkInputData : INetworkInput
    {
        public Vector3 MoveDirection;
        public bool IsSpaceDown;
    }
}