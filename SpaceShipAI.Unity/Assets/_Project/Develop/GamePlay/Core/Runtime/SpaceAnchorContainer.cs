using GamePlay.Core.Interfaces;
using GamePlay.Durability.interfaces;
using GamePlay.Movement.Interfaces;
using GamePlay.Weapon.Interfaces;

namespace GamePlay.Core.Runtime
{
    public class SpaceAnchorContainer : ISpaceAnchor
    {
        public IMovingComponent MovingComponent { get; set; }
        
        public IWeapon MyWeapon { get; set; }
        
        public IAnchorHull MyHull { get; set; }
    }
}