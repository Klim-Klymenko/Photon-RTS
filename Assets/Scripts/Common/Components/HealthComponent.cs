using System;
using UnityEngine;

namespace Common.Components
{
    public sealed class HealthComponent : MonoBehaviour, IDamageable
    {
        public event Action OnDied;
        
        [SerializeField]
        private int _hitPoints;
        
        [SerializeField]
        private int _minHitPoints;

        public void TakeDamage(int damage)
        {
            _hitPoints = Mathf.Max(_minHitPoints, _hitPoints - damage);
           
            if (_hitPoints <= _minHitPoints)
                OnDied?.Invoke();
        }

        private void OnDestroy()
        {
            if (OnDied == null) return;
            
            Delegate[] subscribers = OnDied.GetInvocationList();

            for (int i = 0; i < subscribers.Length; i++)
                OnDied -= (Action) subscribers[i];
        }
    }
}