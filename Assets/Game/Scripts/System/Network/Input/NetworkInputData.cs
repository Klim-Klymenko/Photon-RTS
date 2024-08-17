using Fusion;
using UnityEngine;

namespace System.Network.Input
{
    internal struct NetworkInputData : INetworkInput
    {
        internal Vector3 MoveDirection;
        internal Vector3 MousePosition;
        internal bool IsM0;
    }
}