using System;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public event Action OnDied;

        public int Health => this.hitPoints;

        [SerializeField]
        private int hitPoints = 100;

        public void TakeDamage(int damage)
        {
            if (this.hitPoints > 0)
            {
                this.hitPoints = Mathf.Max(0, hitPoints - damage);
                if (this.hitPoints <= 0)
                {
                    this.OnDied?.Invoke();
                }
            }
        }
    }
}