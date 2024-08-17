using System.Collections.Generic;
using System.Linq;
using Game.GameEngine.Common;
using UnityEngine;

namespace Game.GameEngine.PlayerContext
{
    [RequireComponent(typeof(TeamComponent))]
    public sealed class UnitStack : MonoBehaviour
    {
        private HashSet<GameObject> units;
        private readonly List<GameObject> cache;

        private void Awake()
        {
            TeamAffiliation myAffiliation = this.GetComponent<TeamComponent>().Affiliation;
            
            this.units = new HashSet<GameObject>(GameObject.FindGameObjectsWithTag(GameObjectTags.Unit)
                .Where(it => it.GetComponent<TeamComponent>().Affiliation == myAffiliation));
        }

        public List<GameObject> GetUnits()
        {
            return new List<GameObject>(units);
        }

        private void Update()
        {
            cache.Clear();
            cache.AddRange(units);

            foreach (var o in cache)
            {
                if (o == null)
                {
                    units.Remove(o);
                }
            }
        }
    }
}