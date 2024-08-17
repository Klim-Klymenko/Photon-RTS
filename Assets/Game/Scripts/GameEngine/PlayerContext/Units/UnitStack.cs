using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.GameEngine.PlayerContext
{
    public sealed class UnitStack : ITickable, IEnumerable<GameObject>
    {
        private HashSet<GameObject> _units;

        public void Tick()
        {
            
        }


        public IEnumerator<GameObject> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}