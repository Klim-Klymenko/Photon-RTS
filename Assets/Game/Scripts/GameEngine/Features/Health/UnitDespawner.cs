using Common.Data;
using Fusion;
using UnityEngine;

namespace GameEngine.Features.Health
{
    internal sealed class UnitDespawner : MonoBehaviour
    {
        [SerializeField] 
        private HealthComponent[] _units;
        
        [SerializeField]
        private NetworkRunner _runner;
        
        private void OnEnable()
        {
            for (int i = 0; i < _units.Length; i++)
            {
                HealthComponent unit = _units[i];
                unit.OnDied += Despawn;
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _units.Length; i++)
            {
                HealthComponent unit = _units[i];
                unit.OnDied -= Despawn;
            }
        }

        private void Despawn(NetworkObject networkObject)
        {
            _runner.Despawn(networkObject);
        }
    }
}