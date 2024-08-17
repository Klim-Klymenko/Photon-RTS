using Game.GameEngine.Common;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public TeamAffiliation Affiliation => this.affiliation;

        [SerializeField]
        private TeamAffiliation affiliation;
    }
}