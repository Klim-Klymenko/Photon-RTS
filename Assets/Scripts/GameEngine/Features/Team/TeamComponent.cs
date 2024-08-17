using UnityEngine;

namespace GameEngine.Features.Team
{
    public sealed class TeamComponent : MonoBehaviour
    {
        [field: SerializeField]
        public TeamAffiliation Team { get; private set; }
    }
}