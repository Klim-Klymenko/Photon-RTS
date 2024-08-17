using System;
using UnityEngine;

namespace Game.GameEngine.GameContext
{
    public sealed class OrderInput : MonoBehaviour
    {
        public event Action<Vector3> OnClicked;

        [SerializeField]
        private float rayDistance = 100;

        [SerializeField]
        private LayerMask groundLayer;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit, this.rayDistance, groundLayer))
            {
                return;
            }

            this.OnClicked?.Invoke(hit.point);
        }
    }
}