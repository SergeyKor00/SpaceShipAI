using GamePlay.Core.Interfaces;
using GamePlay.Core.Runtime;
using Zenject;

namespace UnityDisplay.Runtime
{
    public class PlayModeAnchorsFactory : SpaceAnchorsFactory, ISpaceAnchorsFactory
    {
        [Inject] private SpaceEntitiesDisplayer _spaceEntitiesDisplayer;
        
        public new ISpaceAnchor CreateSpaceShip()
        {
            var spaceShip = base.CreateSpaceShip();
            _spaceEntitiesDisplayer.AddSpaceShip(spaceShip);
            return spaceShip;
        }

        public new ISpaceAnchor CreatePlatform()
        {
            var spacePlatform = base.CreatePlatform();
            _spaceEntitiesDisplayer.AddPlatform(spacePlatform);
            return spacePlatform;
        }
        
    }
}