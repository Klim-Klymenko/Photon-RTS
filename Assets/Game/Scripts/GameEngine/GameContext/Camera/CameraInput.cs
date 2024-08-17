using UnityEngine;

namespace Game.GameEngine.GameContext
{
    public sealed class CameraInput
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public Vector3 GetDirection()
        {
            float horizontal = Input.GetAxisRaw(HorizontalAxis);
            float vertical = Input.GetAxisRaw(VerticalAxis);
            return new Vector3(horizontal, 0, vertical).normalized;
        }
    }
}