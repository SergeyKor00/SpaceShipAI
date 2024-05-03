using GamePlay.Core.Interfaces;
using GamePlay.Movement.Runtime;
using UnityEngine;
using Zenject;

namespace GamePlay.Core.Runtime
{
    public class SpaceAnchorsFactory : ISpaceAnchorsFactory
    {
        [Inject] protected DiContainer _diContainer;
        

        public ISpaceAnchor CreateSpaceShip()
        {
            var movement = new SpaceShip();
            _diContainer.Inject(movement);

            var spaceShipContainer = new SpaceAnchorContainer(movement);
            _diContainer.Inject(spaceShipContainer);
            
            return spaceShipContainer;
        }

        public ISpaceAnchor CreatePlatform()
        {
            
            var movement = new StaticPlatform(Vector2.zero);
            
            _diContainer.Inject(movement);
            
            var spaceShipContainer = new SpaceAnchorContainer(movement);
            _diContainer.Inject(spaceShipContainer);
            
            return spaceShipContainer;
        }
    }
}