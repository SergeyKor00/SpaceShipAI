using GamePlay.Controller.Interfases;
using GamePlay.Controller.Runtime;
using GamePlay.Core.Interfaces;
using GamePlay.Core.Runtime;
using GamePlay.Movement.Interfaces;
using UnityEngine;
using Zenject;

namespace UnityDisplay.Runtime
{
    public class UnityDisplayInstaller : MonoInstaller
    {
        [SerializeField] private SpaceEntitiesDisplayer _spaceEntitiesDisplayer;
        [SerializeField] private MovingConfig _movingConfig;
        [SerializeField] private UnityTimer _unityTimer;
        
        
        public override void InstallBindings()
        {
            Container.Bind<SpaceEntitiesDisplayer>().FromInstance(_spaceEntitiesDisplayer);
            Container.Bind<IMovementConfig>().To<MovingConfig>().FromInstance(_movingConfig);
            Container.Bind<ISpaceAnchorsFactory>().To<PlayModeAnchorsFactory>().FromNew().AsSingle();
            Container.Bind<IGameTimer>().To<UnityTimer>().FromInstance(_unityTimer);
            Container.Bind<GameEngine>().FromNew().AsSingle();
            Container.Bind<ISpaceAnchorsStorage>().To<SpaceAnchorsStorage>().FromNew().AsSingle();
            Container.Bind<IUserInputReceiver>().To<SpaceShipInputReceiver>().FromNew().AsSingle();
        }
    }
}