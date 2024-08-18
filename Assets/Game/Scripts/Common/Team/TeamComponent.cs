using UnityEngine;

namespace Game.GameEngine.Common
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public TeamAffiliation Affiliation => this.affiliation;

        [SerializeField]
        private TeamAffiliation affiliation;
    }
}