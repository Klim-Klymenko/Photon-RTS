using System.Collections.Generic;
using System.GameCycle;
using Common.Data;
using UnityEngine;

namespace Common.Installation
{
    public abstract class Context : MonoBehaviour
    {
        [SerializeReference] 
        private IFeatureInstaller[] _installers;

        protected ServiceLocator ServiceLocator { get; } = new();
        
        protected void InvokeInstallers(IList<IGameListener> gameListeners = null)
        {
            for (int i = 0; i < _installers.Length; i++)
            {
                _installers[i].Install(ServiceLocator, gameListeners);
            }
        }
    }
}