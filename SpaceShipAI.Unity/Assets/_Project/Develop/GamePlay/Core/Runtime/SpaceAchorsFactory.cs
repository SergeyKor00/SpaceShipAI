using GamePlay.Core.Interfaces;
using GamePlay.Durability;
using GamePlay.Durability.interfaces;
using GamePlay.Movement.Runtime;
using GamePlay.Weapon;
using GamePlay.Weapon.Interfaces;
using GamePlay.Weapon.Runtime;
using UnityEngine;
using Zenject;

namespace GamePlay.Core.Runtime
{
    public class SpaceAnchorsFactory : ISpaceAnchorsFactory
    {
        [Inject] protected DiContainer _diContainer;
        [Inject] protected IWeaponConfig _weaponConfig;
        [Inject] private IHullConfig _hullConfig;
        
        
        public ISpaceAnchor CreateSpaceShip()
        {
            var movement = new SpaceShip();
            _diContainer.Inject(movement);
            
            
            var spaceShipContainer = new SpaceAnchorContainer();
            spaceShipContainer.MovingComponent = movement;
            _diContainer.Inject(spaceShipContainer);

            var weapon = CreateWeapon(_weaponConfig.WeaponType, spaceShipContainer);
            _diContainer.Inject(weapon);
            spaceShipContainer.MyWeapon = weapon;

            var hull = new SimpleAnchorHull(_hullConfig, spaceShipContainer);
            _diContainer.Inject(hull);
            spaceShipContainer.MyHull = hull;
            
            return spaceShipContainer;
        }

        private IWeapon CreateWeapon(WeaponType type, ISpaceAnchor anchor)
        {
            switch (type)
            {
                case WeaponType.AutoCannon:
                    return new AutoTargetingCannon(_weaponConfig.StartRange, _weaponConfig.StartPower, 0.5f, anchor);
                
                default:
                    return new AutoTargetingCannon(_weaponConfig.StartRange, _weaponConfig.StartPower, 0.5f, anchor);
            }
        }
        
        
        public ISpaceAnchor CreatePlatform()
        {
            
            var movement = new StaticPlatform(Vector2.zero);
            _diContainer.Inject(movement);
            
            var spaceShipContainer = new SpaceAnchorContainer();
            spaceShipContainer.MovingComponent = movement;
            
            _diContainer.Inject(spaceShipContainer);
            
            var hull = new SimpleAnchorHull(_hullConfig, spaceShipContainer);
            _diContainer.Inject(hull);
            spaceShipContainer.MyHull = hull;
            
            return spaceShipContainer;
        }
    }
}