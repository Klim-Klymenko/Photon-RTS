using System;
using System.Collections.Generic;
using System.GameCycle;
using System.Network.Input;
using Common.Data;
using Common.Installation;
using UnityEngine;

namespace GameEngine.Entities.Movement
{
    [Serializable]
    internal sealed class MovementInstaller : IFeatureInstaller
    {
        [SerializeField] 
        private Transform _transform;

        [SerializeField]
        private float _speed;
        
        void IFeatureInstaller.Install(ServiceLocator serviceLocator, IList<IGameListener> gameListeners)
        {
            NetworkInputFacade input = serviceLocator.GetData<NetworkInputFacade>();
            
            CamComponent camComponent = new(_transform, _speed);
            MovementController movementController = new(camComponent, input);
            
            gameListeners.Add(movementController);
        }
    }
}