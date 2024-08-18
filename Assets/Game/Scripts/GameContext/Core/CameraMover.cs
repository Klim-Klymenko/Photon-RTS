using UnityEngine;

namespace Game.GameEngine.GameContext
{
    public sealed class CameraMover : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed = 5;

        private Transform _cameraTransform;
        private CameraInput _input;

        private void Awake()
        {
            _cameraTransform = Camera.main!.transform;
            _input = this.GetComponent<CameraInput>();
        }

        private void Update()
        {
            _cameraTransform.position += _input.GetDirection() * (this.movementSpeed * Time.deltaTime);
        }
    }
}