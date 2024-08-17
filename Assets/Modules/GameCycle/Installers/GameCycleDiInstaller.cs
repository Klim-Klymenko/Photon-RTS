using UnityEngine;
using Zenject;

namespace System.GameCycle
{
    internal sealed class GameCycleDiInstaller : MonoInstaller, IFinishable
    {
        [SerializeField]
        private SceneContext _sceneContext;
        
        [SerializeField] 
        private SceneGameCycleManager _gameCycleManager;
        
        private GameCycleManagerInstaller _gameCycleManagerInstaller;
        
        public override void InstallBindings()
        {
            BindGameCycleManager();
            BindGameCycleManagerInstaller();
            
            _sceneContext.PostResolve += InstallListeners;
        }

        private void BindGameCycleManager()
        {
            Container.BindInterfacesAndSelfTo<SceneGameCycleManager>().FromInstance(_gameCycleManager).AsSingle();
        }
        
        private void BindGameCycleManagerInstaller()
        {
            Container.Bind<GameCycleManagerInstaller>().AsSingle()
                .OnInstantiated<GameCycleManagerInstaller>((_, it) => _gameCycleManagerInstaller = it).NonLazy();
        }
        
        void IFinishable.OnFinish()
        {
            _sceneContext.PostResolve -= InstallListeners;
        }
        
        private void InstallListeners()
        {
            _gameCycleManagerInstaller.InstallListeners();
            _gameCycleManager.OnInitialize();
        }
    }
}