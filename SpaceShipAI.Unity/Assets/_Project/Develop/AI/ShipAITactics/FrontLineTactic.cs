using GamePlay.Controller.Interfases;
using GamePlay.Controller.Runtime;
using GamePlay.Core.Interfaces;
using GamePlay.Movement.Interfaces;
using UnityEngine;
using Zenject;

namespace AI.ShipAITactics
{
    public class FrontLineTactic : BaseShipTactic, IShipAITactic
    {
        private bool _needsRotation;
        private BehaviourState _currState;
        private float _currAcceleration;
        private float _rotationValue;
        
        public FrontLineTactic(IMovementConfig movementConfig, IShipMovementController movementController) : base(movementController, movementConfig)
        {
            
        }


        [Inject]
        private void Setup()
        {
            _gameTimer.AddTickableEvent(Tick);
        }

        protected override void Tick(float deltatime)
        {
            if (_currState == BehaviourState.MoveToEnemy)
            {
                CheckWeaponInRange(deltatime);
            }
        }

        private void CalculateNextStage()
        {
            if (EnemyInWeaponRange())
            {
                _currState = BehaviourState.FireAndBreaking;
                _spaceAnchor.MyWeapon.FireKeyDown();
            }
            else
            {
                _currState = BehaviourState.MoveToEnemy;
                _movementController.SetTargetSpeed(_shipMovementConfig.MovingSpeed, null);
            }
        }


        private void CheckWeaponInRange(float deltaTime)
        {
            if (EnemyInWeaponRange())
            {
                _currState = BehaviourState.FireAndBreaking;
                _movementController.SetTargetSpeed(0.0f, null);
                _spaceAnchor.MyWeapon.FireKeyDown();
            }
            
        }
        
        
        public void SetControllOnShip(ISpaceAnchor spaceAnchor, ISpaceAnchor enemy)
        {
            _spaceAnchor = spaceAnchor;
            _enemy = enemy;
            _weaponRange = _spaceAnchor.MyWeapon.Range;
            _movementController.RotateToDirection(enemy.MovingComponent.Position - spaceAnchor.MovingComponent.Position, CalculateNextStage);
        }


        private enum BehaviourState
        {
            None, RotateToEnemy, MoveToEnemy, FireAndBreaking
        }


    }
}