using UnityEngine;

namespace Fusion.Input
{
    public sealed class LocalInputFacade : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        private const KeyCode SpaceKey = KeyCode.Space;
        
        public Vector3 GetDirection()
        {
            float horizontal = UnityEngine.Input.GetAxisRaw(HorizontalAxis);
            float vertical = UnityEngine.Input.GetAxisRaw(VerticalAxis);
            
            return new Vector3(horizontal, 0, vertical).normalized;
        }

        public bool GetSpaceDown()
        {
            return UnityEngine.Input.GetKeyDown(SpaceKey);
        }
    }
}