using Common.Data;
using Common.Installation;
using UnityEngine;

namespace GameEngine.Objects.Unit
{
    internal sealed class UnitContext : Context
    {
        [SerializeField]
        private MonoBehaviour[] _components;
        
        private void Awake()
        {
            InvokeInstallers();
        }
    }
}