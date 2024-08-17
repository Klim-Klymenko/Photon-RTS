using System;
using Game.GameEngine.Common;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class TeamColorRule : MonoBehaviour
    {
        [SerializeField]
        private TeamComponent _teamComponent;

        [SerializeField]
        private Renderer _renderer;
        
        private void Awake()
        {
            this.UpdateColor();
        }

        private void Reset()
        {
            this.UpdateColor();
        }

        private void OnValidate()
        {
            this.UpdateColor();
        }

        private void UpdateColor()
        {
            Material teamMaterial = TeamAffilationConfig.Instance.GetMaterial(_teamComponent.Affiliation);
            _renderer.material = teamMaterial;
        }
    }
}