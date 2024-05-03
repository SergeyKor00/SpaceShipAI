using GamePlay.Core.Interfaces;
using GamePlay.Movement.Interfaces;

namespace GamePlay.Core.Runtime
{
    public class SpaceAnchorContainer : ISpaceAnchor
    {
        private IMovingComponent _movingComponent;

        public SpaceAnchorContainer(IMovingComponent movingComponent)
        {
            _movingComponent = movingComponent;
        }


        public IMovingComponent MovingComponent => _movingComponent;
    }
}