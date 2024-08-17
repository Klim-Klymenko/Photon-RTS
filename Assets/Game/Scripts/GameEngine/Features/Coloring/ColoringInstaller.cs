using System;
using System.Collections.Generic;
using System.GameCycle;
using Common.Data;
using Common.Installation;
using GameEngine.Objects.Unit;

namespace GameEngine.Features.Coloring
{
    [Serializable]
    internal sealed class ColoringInstaller : IFeatureInstaller
    {
        void IFeatureInstaller.Install(ServiceLocator serviceLocator, IList<IGameListener> gameListeners)
        {
            UnitService unitService = serviceLocator.GetData<UnitService>();
            
            ColoringComponent coloringComponent = new(unitService);
            gameListeners.Add(coloringComponent);
        }
    }
}