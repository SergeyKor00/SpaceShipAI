using GamePlay.Movement.Interfaces;

namespace GamePlay.Core.Interfaces
{
    public interface ISpaceAnchor
    {
        IMovingComponent MovingComponent { get; }
    }
}