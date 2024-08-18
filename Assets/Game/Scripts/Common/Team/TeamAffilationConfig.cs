using System;
using UnityEngine;

namespace Game.GameEngine.Common
{
    [CreateAssetMenu(
        fileName = "TeamAffilationConfig",
        menuName = "Game/GameEngine/New TeamAffilationConfig"
    )]
    public sealed class TeamAffilationConfig : ScriptableObject
    {
        public static TeamAffilationConfig Instance
        {
            get { return Resources.Load<TeamAffilationConfig>(nameof(TeamAffilationConfig)); }
        }

        [SerializeField]
        private TeamAffilationInfo[] teams;

        public Color GetColor(TeamAffiliation affiliation)
        {
            return this.GetInfo(affiliation).color;
        }

        public Material GetMaterial(TeamAffiliation affiliation)
        {
            return this.GetInfo(affiliation).material;
        }

        public TeamAffilationInfo GetInfo(TeamAffiliation affiliation)
        {
            foreach (TeamAffilationInfo info in teams)
            {
                if (info.affilation == affiliation)
                {
                    return info;
                }
            }

            throw new Exception($"Team affilation \"{affiliation}\" is not found!");
        }
    }
}