using System;
using System.Collections.Generic;
using System.GameCycle;
using Common.Data;
using Common.Installation;
using UnityEngine;

namespace GameEngine.Features.Switching
{
    [Serializable]
    internal sealed class SwitchingInstaller : IFeatureInstaller
    {
        [SerializeField]
        private GameObject _gameObject;
        
        void IFeatureInstaller.Install(ServiceLocator serviceLocator, IList<IGameListener> gameListeners)
        {
            SwitchingComponent switchingComponent = new(_gameObject);
            gameListeners.Add(switchingComponent);
        }
    }
}