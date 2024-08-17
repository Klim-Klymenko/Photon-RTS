using System.Collections.Generic;
using System.GameCycle;
using System.Network.Input;
using Common.Installation;
using Fusion;
using UnityEngine;

namespace GameEngine.Objects.Player
{
    internal sealed class PlayerContext : Context
    {
        [SerializeField] 
        private GameObjectGameCycleManager _gameCycleManager;
        
        [SerializeField] 
        private NetworkInputReceiver _inputReceiver;
        
        [SerializeField]
        private NetworkObject _networkObject;
        
        private void Awake()
        {
            List<IGameListener> gameListeners = new();
            
            NetworkInputFacade inputFacade = new();
            ServiceLocator.AddData(inputFacade);
            
            InvokeInstallers(gameListeners);

            _inputReceiver.Construct(inputFacade);
            InstallGameListeners(gameListeners);
            
            _gameCycleManager.OnInitialize();
        }
        
        private void InstallGameListeners(List<IGameListener> gameListeners)
        {
            for (int i = 0; i < gameListeners.Count; i++)
            {
                _gameCycleManager.AddListener(gameListeners[i]);
            }
        }
    }
}