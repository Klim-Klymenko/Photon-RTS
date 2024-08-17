using System.Collections.Generic;
using Fusion;

namespace System.GameCycle
{
    public sealed class SceneGameCycleManager : SimulationBehaviour, IGameCycleManager, IPlayerJoined, IPlayerLeft
    {
        private GameState _gameState;

        private readonly List<IInitializable> _initializableListeners = new();
        private readonly List<IStartable> _startableListeners = new();
        private readonly List<IUpdatable> _updatableListeners = new();
        private readonly List<IFixedUpdatableNetwork> _fixedUpdatableNetworkListeners = new();
        private readonly List<IFixedUpdatable> _fixedUpdatableListeners = new();
        private readonly List<IRenderable> _renderableListeners = new();
        private readonly List<ILateUpdatable> _lateUpdatableListeners = new();
        private readonly List<IFinishable> _finishableListeners = new();
        private readonly List<IPlayerJoinable> _joinableListeners = new();
        private readonly List<IPlayerLeaveable> _leaveableListeners = new();

        public void OnInitialize()
        {
            if (_gameState != GameState.None) return;
            
            for (int i = 0; i < _initializableListeners.Count; i++)
                _initializableListeners[i].OnInitialize();
            
            _gameState = GameState.Initialized;
        }

        private void Start()
        {
            if (_gameState != GameState.Initialized) return;
            
            for (int i = 0; i < _startableListeners.Count; i++)
                _startableListeners[i].OnStart();
            
            _gameState = GameState.Active;
        }
        
        private void Update()
        {
            if (_gameState != GameState.Active) return;
            
            for (int i = 0; i < _updatableListeners.Count; i++)
                _updatableListeners[i].OnUpdate();
        }

        public override void FixedUpdateNetwork()
        {
            if (_gameState != GameState.Active) return;
            
            for (int i = 0; i < _fixedUpdatableNetworkListeners.Count; i++)
                _fixedUpdatableNetworkListeners[i].OnFixedUpdateNetwork(Runner, Object);
        }

        private void FixedUpdate()
        {
            if (_gameState != GameState.Active) return;
            
            for (int i = 0; i < _fixedUpdatableListeners.Count; i++)
                _fixedUpdatableListeners[i].OnFixedUpdate();
        }

        public override void Render()
        {
            if (_gameState != GameState.Active) return;
            
            for (int i = 0; i < _renderableListeners.Count; i++)
                _renderableListeners[i].OnRender(Runner, Object);
        }

        private void LateUpdate()
        {
            if (_gameState != GameState.Active) return;
            
            for (int i = 0; i < _lateUpdatableListeners.Count; i++)
                _lateUpdatableListeners[i].OnLateUpdate();
        }

        private void OnApplicationQuit()
        {
            if (_gameState == GameState.Finished) return;
            
            for (int i = 0; i < _finishableListeners.Count; i++)
                _finishableListeners[i].OnFinish();
            
            _gameState = GameState.Finished;
        }
        
        void IPlayerJoined.PlayerJoined(PlayerRef playerRef)
        {
            if (_gameState is GameState.None or GameState.Finished) return;

            for (int i = 0; i < _joinableListeners.Count; i++)
            {
                _joinableListeners[i].OnPlayerJoined(playerRef);
            }
        }

        void IPlayerLeft.PlayerLeft(PlayerRef playerRef)
        {
            if (_gameState == GameState.None) return;
            
            for (int i = 0; i < _leaveableListeners.Count; i++)
            {
                _leaveableListeners[i].OnPlayerLeft(playerRef);
            }
        }
        
        public void AddListener(IGameListener listener)
        {
            if (listener is IInitializable initializable)
            {
                if (!_initializableListeners.Contains(initializable))
                {
                    _initializableListeners.Add(initializable);

                    if (_gameState is GameState.Initialized or GameState.Active)
                        initializable.OnInitialize();
                }
            }
            
            if (listener is IStartable startable)
            {
                if (!_startableListeners.Contains(startable))
                {
                    _startableListeners.Add(startable);

                    if (_gameState == GameState.Active)
                        startable.OnStart();
                }
            }

            if (listener is IUpdatable updatable)
            {
                if (!_updatableListeners.Contains(updatable))
                    _updatableListeners.Add(updatable);
            }

            if (listener is IFixedUpdatableNetwork fixedUpdatableNetwork)
            {
                if (!_fixedUpdatableNetworkListeners.Contains(fixedUpdatableNetwork))
                    _fixedUpdatableNetworkListeners.Add(fixedUpdatableNetwork);
            }
            
            if (listener is IFixedUpdatable fixedUpdatable)
            {
                if (!_fixedUpdatableListeners.Contains(fixedUpdatable))
                    _fixedUpdatableListeners.Add(fixedUpdatable);
            }

            if (listener is IRenderable renderable)
            {
                if (!_renderableListeners.Contains(renderable))
                    _renderableListeners.Add(renderable);
            }
            
            if (listener is ILateUpdatable lateUpdatable)
            {
                if (!_lateUpdatableListeners.Contains(lateUpdatable))
                    _lateUpdatableListeners.Add(lateUpdatable);
            }

            if (listener is IFinishable finishable)
            {
                if (!_finishableListeners.Contains(finishable))
                    _finishableListeners.Add(finishable);
            }
            
            if (listener is IPlayerJoinable playerJoinable)
            {
                if (!_joinableListeners.Contains(playerJoinable))
                    _joinableListeners.Add(playerJoinable);
            }
            
            if (listener is IPlayerLeaveable playerLeaveable)
            {
                if (!_leaveableListeners.Contains(playerLeaveable))
                    _leaveableListeners.Add(playerLeaveable);
            }
        }
        
        public void RemoveListener(IGameListener listener)
        {
            if (listener is IInitializable initializable)
            {
                if (_initializableListeners.Contains(initializable))
                    _initializableListeners.Remove(initializable);
            }

            if (listener is IUpdatable updatable)
            {
                if (_updatableListeners.Contains(updatable))
                    _updatableListeners.Remove(updatable);
            }

            if (listener is IFixedUpdatableNetwork fixedUpdatableNetwork)
            {
                if (_fixedUpdatableNetworkListeners.Contains(fixedUpdatableNetwork))
                    _fixedUpdatableNetworkListeners.Remove(fixedUpdatableNetwork);
            }
            
            if (listener is IFixedUpdatable fixedUpdatable)
            {
                if (_fixedUpdatableListeners.Contains(fixedUpdatable))
                    _fixedUpdatableListeners.Remove(fixedUpdatable);
            }
            
            if (listener is IRenderable renderable)
            {
                if (_renderableListeners.Contains(renderable))
                    _renderableListeners.Remove(renderable);
            }

            if (listener is ILateUpdatable lateUpdatable)
            {
                if (_lateUpdatableListeners.Contains(lateUpdatable))
                    _lateUpdatableListeners.Remove(lateUpdatable);
            }

            if (listener is IFinishable finishable)
            {
                if (_finishableListeners.Contains(finishable))
                    _finishableListeners.Remove(finishable);
            }
            
            if (listener is IPlayerJoinable playerJoinable)
            {
                if (_joinableListeners.Contains(playerJoinable))
                    _joinableListeners.Remove(playerJoinable);
            }
            
            if (listener is IPlayerLeaveable playerLeaveable)
            {
                if (_leaveableListeners.Contains(playerLeaveable))
                    _leaveableListeners.Remove(playerLeaveable);
            }
        }
    }
}