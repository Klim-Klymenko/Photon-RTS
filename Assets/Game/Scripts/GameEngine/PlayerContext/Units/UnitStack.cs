using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameEngine.PlayerContext
{
    public sealed class UnitStack : IEnumerable<GameObject>
    {
        private HashSet<GameObject> _units;

        public void Tick()
        {
            
        }


        public IEnumerator<GameObject> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}