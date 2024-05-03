using GamePlay.Core.Interfaces;

namespace GamePlay.Weapon.Interfaces
{
    public interface IShellsFactory
    {
        IShellAnchor CreateShell(WeaponType weaponType, ISpaceAnchor anchor);
    }
}