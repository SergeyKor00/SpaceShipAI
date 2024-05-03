using GamePlay.Core.Interfaces;
using GamePlay.Weapon.Interfaces;
using UnityEngine;
using Zenject;

namespace GamePlay.Weapon.Runtime
{
    public class AutoTargetingCannon : IWeapon
    {
        [Inject] private IGameTimer _gameTimer;
        [Inject] private IShellsFactory _shellsFactory;
        
        
        private float _range;
        private bool _fireKeyDown;
        private float _power;
        private float _fireFrecuency;
        private float _timeSinceLastShoot;
        private ISpaceAnchor _enemyAnchor, _myAnchor;
            
        
        public float Range => _range;

        public AutoTargetingCannon(float range, float power, float fireFrecuency, ISpaceAnchor anchor)
        {
            _range = range;
            _power = power;
            _fireFrecuency = fireFrecuency;
            _myAnchor = anchor;
        }
        
        
        [Inject]
        private void Setup()
        {
            _gameTimer.AddTickableEvent(Tick);
        }

        
       

        public void FireKeyDown()
        {
            _fireKeyDown = true;
        }

        public void FireKeyUp()
        {
            _fireKeyDown = false;
        }

        public void SetEnemy(ISpaceAnchor anchor)
        {
            _enemyAnchor = anchor;
        }

        private void Tick(float deltatime)
        {
            if (_timeSinceLastShoot > 0.0f)
            {
                _timeSinceLastShoot -= deltatime;
                return;
            }
            
            if(!_fireKeyDown || _enemyAnchor == null)
                return;

            if (Vector2.SqrMagnitude(_enemyAnchor.MovingComponent.Position - _myAnchor.MovingComponent.Position) <
                _range * _range)
            {
                Debug.Log("Fire");
                _timeSinceLastShoot = _fireFrecuency;
                var shell = _shellsFactory.CreateShell(WeaponType.AutoCannon, _myAnchor);
                shell.SetTargetEnemy(_enemyAnchor);
            }
        }
        
    }
}