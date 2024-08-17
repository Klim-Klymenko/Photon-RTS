using System.Collections.Generic;
using Fusion;

namespace System.GameCycle
{
    public class GameObjectGameCycleManager : NetworkBehaviour, IGameCycleManager
    {
        private GameState _gameState;

        private readonly List<IInitializable> _initializableListeners = new();
        private readonly List<ISpawnable> _spawnableListeners = new();
        private readonly List<IUpdatable> _updatableListeners = new();
        private readonly List<IFixedUpdatableNetwork> _fixedUpdatableNetworkListeners = new();
        private readonly List<IFixedUpdatable> _fixedUpdatableListeners = new();
        private readonly List<IRenderable> _renderableListeners = new();
        private readonly List<ILateUpdatable> _lateUpdatableListeners = new();
        private readonly List<IDespawnable> _despawnableListeners = new();

        public void OnInitialize()
        {
            if (_gameState != GameState.None) return;
            
            for (int i = 0; i < _initializableListeners.Count; i++)
                _initializableListeners[i].OnInitialize();
            
            _gameState = GameState.Initialized;
        }

        public override void Spawned()
        {
            if (_gameState != GameState.Initialized) return;
            
            for (int i = 0; i < _spawnableListeners.Count; i++)
                _spawnableListeners[i].OnSpawned(Runner, Object);
            
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
        
        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            if (_gameState is GameState.None or GameState.Finished) return;
            
            for (int i = 0; i < _despawnableListeners.Count; i++)
                _despawnableListeners[i].OnDespawned(Runner, Object);
            
            _gameState = GameState.Finished;
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
            
            if (listener is ISpawnable spawnable)
            {
                if (!_spawnableListeners.Contains(spawnable))
                {
                    _spawnableListeners.Add(spawnable);
                    
                    if (_gameState == GameState.Active)
                        spawnable.OnSpawned(Runner, Object);
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

            if (listener is IDespawnable despawnable)
            {
                if (!_despawnableListeners.Contains(despawnable))
                    _despawnableListeners.Add(despawnable);
            }
        }
        
        public void RemoveListener(IGameListener listener)
        {
            if (listener is IInitializable initializable)
            {
                if (_initializableListeners.Contains(initializable))
                    _initializableListeners.Remove(initializable);
            }

            if (listener is ISpawnable spawnable)
            {
                if (_spawnableListeners.Contains(spawnable))
                    _spawnableListeners.Remove(spawnable);
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
            
            if (listener is IDespawnable despawnable)
            {
                if (_despawnableListeners.Contains(despawnable))
                    _despawnableListeners.Remove(despawnable);
            }
        }
    }
}