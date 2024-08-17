using UnityEngine;

namespace GameEngine.Entities
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed = 5.0f;
        
        public void Move(Vector3 normalizedDirection, float deltaTime)
        {
            this.transform.position += normalizedDirection * (this.movementSpeed * deltaTime);
        }
    }
}