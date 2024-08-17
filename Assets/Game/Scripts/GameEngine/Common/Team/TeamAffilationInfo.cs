using System;
using UnityEngine;

namespace Game.GameEngine.Common
{
    [Serializable]
    public sealed class TeamAffilationInfo
    {
        [field: SerializeField]
        public TeamAffiliation affilation { get; private set; }

        [field: SerializeField]
        public Material material { get; private set; }

        [field: SerializeField]
        public Color color { get; private set; }
    }
}