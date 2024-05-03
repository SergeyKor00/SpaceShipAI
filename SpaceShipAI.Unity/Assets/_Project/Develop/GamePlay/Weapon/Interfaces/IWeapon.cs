using GamePlay.Core.Interfaces;

namespace GamePlay.Weapon.Interfaces
{
    public interface IWeapon
    {
        float Range { get; }

        void FireKeyDown();

        void FireKeyUp();

        void SetEnemy(ISpaceAnchor anchor);
    }
}