namespace GamePlay.Weapon.Interfaces
{
    public interface IWeaponConfig
    {
        public float StartRange { get; }

        public float StartPower { get; }
        
        public WeaponType WeaponType { get; }
    }
}