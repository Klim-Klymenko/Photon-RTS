using UnityEngine;

namespace Common.LocalInput
{
    public sealed class LocalInputFacade : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        private const KeyCode SpaceKey = KeyCode.Space;
        
        public Vector3 GetDirection()
        {
            float horizontal = Input.GetAxisRaw(HorizontalAxis);
            float vertical = Input.GetAxisRaw(VerticalAxis);
            
            return new Vector3(horizontal, 0, vertical).normalized;
        }
        
        public Vector3 MousePosition => Input.mousePosition;
        public bool IsM0 => Input.GetMouseButton(0);
    }
}