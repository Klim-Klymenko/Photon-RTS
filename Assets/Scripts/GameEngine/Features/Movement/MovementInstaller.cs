using System;
using System.Collections.Generic;
using System.GameCycle;
using System.Network.Input;
using Common.Data;
using Common.Installation;
using UnityEngine;

namespace GameEngine.Features.Movement
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
            
            MovementComponent movementComponent = new(_transform, _speed);
            MovementController movementController = new(movementComponent, input);
            
            gameListeners.Add(movementController);
        }
    }
}