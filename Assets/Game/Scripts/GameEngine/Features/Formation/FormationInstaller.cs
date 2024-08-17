using System;
using System.Collections.Generic;
using System.GameCycle;
using System.Network.Input;
using Common.Data;
using Common.Installation;
using Fusion;
using GameEngine.Objects.Unit;
using UnityEngine;

namespace GameEngine.Entities.Formation
{
    [Serializable]
    internal sealed class FormationInstaller : IFeatureInstaller
    {
        [SerializeField]
        private Camera _camera;
        
        [SerializeField]
        private float _maxRayDistance;
        
        [SerializeField]
        private LayerMask _groundLayer;

        void IFeatureInstaller.Install(ServiceLocator serviceLocator, IList<IGameListener> gameListeners)
        {
            UnitService unitService = serviceLocator.GetData<UnitService>();
            NetworkInputFacade input = serviceLocator.GetData<NetworkInputFacade>();
            
            FormationComponent formationComponent = new(unitService);
            FormationController formationController = new(formationComponent, input, _camera, _maxRayDistance, _groundLayer);
            
            gameListeners.Add(formationComponent);
            gameListeners.Add(formationController);
        }
    }
}