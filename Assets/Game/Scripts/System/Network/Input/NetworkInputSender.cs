using Common.LocalInput;
using Fusion;
using UnityEngine;

namespace System.Network.Input
{
    public sealed class NetworkInputSender : MonoBehaviour
    {
        [SerializeField]
        private LocalInputFacade _localInputFacade;
        
        public void SendInput(ref NetworkInput networkInput)
        {
            NetworkInputData inputData = new NetworkInputData
            {
                MoveDirection = _localInputFacade.GetDirection(),
                MousePosition = _localInputFacade.MousePosition,
                IsM0 = _localInputFacade.IsM0
            };
            
            networkInput.Set(inputData);
        }
    }
}