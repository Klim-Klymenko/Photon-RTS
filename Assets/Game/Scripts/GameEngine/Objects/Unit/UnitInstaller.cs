using System;
using System.Collections.Generic;
using System.GameCycle;
using Common.Data;
using Common.Installation;

namespace GameEngine.Objects.Unit
{
    [Serializable]
    internal sealed class UnitInstaller : IFeatureInstaller
    {
        void IFeatureInstaller.Install(ServiceLocator serviceLocator, IList<IGameListener> gameListeners)
        {
            UnitService unitService = new();
            
            gameListeners.Add(unitService);
            serviceLocator.AddData(unitService);
        }
    }
}