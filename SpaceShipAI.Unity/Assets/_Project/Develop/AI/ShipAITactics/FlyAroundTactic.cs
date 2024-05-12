using System;
using GamePlay.Controller.Interfases;
using GamePlay.Core.Interfaces;
using GamePlay.Movement.Interfaces;
using UnityEngine;
using Zenject;

namespace AI.ShipAITactics
{
    public class FlyAroundTactic : BaseShipTactic
    {
        private float _targetOrbitalSpeed;
        private float _targetRotationCoeff;

        private Action<float> _tickAction;
        
        protected override void Tick(float deltatime)
        {
            _tickAction?.Invoke(deltatime);
        }
        
        
        public FlyAroundTactic(IShipMovementController movementController, IMovementConfig shipMovementConfig) : base(movementController, shipMovementConfig)
        {
           
        }

        public void SetControllOnShip(ISpaceAnchor spaceAnchor, ISpaceAnchor enemy)
        {
            _spaceAnchor = spaceAnchor;
            _enemy = enemy;
            CalculateOrbitalSpeed();
            if (EnemyInWeaponRange())
            {
                _spaceAnchor.MyWeapon.FireKeyDown();
                _movementController.SetTargetSpeed(_targetOrbitalSpeed);
                _tickAction = MoveToTargetOrbital;
            }
            else
            {
                
            }
        }

        private void MoveToTargetOrbital(float deltaTime)
        {
            
            
        }


        private void MoveToOrbitalFromOutSide(float deltaTime)
        {
            
        }
        
        private void CalculateOrbitalSpeed()
        {
            var maxRotationSpeedInRad = Mathf.Deg2Rad * _shipMovementConfig.RotationSpeed;
            var possibleSpeed = maxRotationSpeedInRad * _weaponRange;
            _targetOrbitalSpeed = possibleSpeed < _shipMovementConfig.MovingSpeed ? possibleSpeed : _shipMovementConfig.MovingSpeed;

            var targetRotationSpeed = _targetOrbitalSpeed / _weaponRange;
            _targetRotationCoeff = targetRotationSpeed / maxRotationSpeedInRad;
        }
        
        
    }
}