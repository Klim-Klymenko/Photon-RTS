using System.Collections.Generic;
using System.GameCycle;
using Common.Data;

namespace Common.Installation
{
    public interface IFeatureInstaller
    {
        void Install(ServiceLocator serviceLocator, IList<IGameListener> gameListeners = null);
    }
}