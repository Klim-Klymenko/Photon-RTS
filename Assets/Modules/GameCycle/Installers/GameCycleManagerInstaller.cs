using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace System.GameCycle
{
    [UsedImplicitly]
    internal sealed class GameCycleManagerInstaller
    {
        private readonly IGameCycleManager _gameCycleManager;
        private readonly List<IGameListener> _gameListeners;
        
        internal GameCycleManagerInstaller(IGameCycleManager gameCycleManager, List<IGameListener> gameListeners)
        {
            _gameCycleManager = gameCycleManager;
            _gameListeners = gameListeners;
        }

        internal void InstallListeners()
        {
            InstallSystemListeners();
            InstallSceneListeners();
        }
        
        private void InstallSystemListeners()
        {
            for (int i = 0; i < _gameListeners.Count; i++)
            {
                _gameCycleManager.AddListener(_gameListeners[i]);
            }
        }
        
        private void InstallSceneListeners()
        {
            IReadOnlyList<MonoBehaviour> components = UnityEngine.Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is IGameListener gameListener)
                    _gameCycleManager.AddListener(gameListener);
            }
        }
    }
}