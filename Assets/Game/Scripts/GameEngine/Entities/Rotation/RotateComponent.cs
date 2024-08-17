using UnityEngine;

namespace GameEngine.Entities
{
    public sealed class RotateComponent : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed = 0.1f;

        public void Rotate(Vector3 normalizedDirection)
        {
            Quaternion lookRotation = Quaternion.LookRotation(normalizedDirection);
            Quaternion smoothedRotation = Quaternion.Slerp(this.transform.rotation, lookRotation, this.rotationSpeed);
            this.transform.rotation = smoothedRotation;
        }
    }
}