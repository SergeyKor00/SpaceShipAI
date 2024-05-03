using GamePlay.Movement.Interfaces;
using GamePlay.Weapon.Interfaces;

namespace GamePlay.Core.Interfaces
{
    public interface ISpaceAnchor
    {
        IMovingComponent MovingComponent { get; }
        
        IWeapon MyWeapon { get; }
    }
}