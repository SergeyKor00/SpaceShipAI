using GamePlay.Core.Interfaces;
using GamePlay.Movement.Interfaces;
using UnityEngine;
using Zenject;

namespace AI.ShipAITactics
{
    public class FrontLineTactic : IShipAITactic
    {
        [Inject] private IGameTimer _gameTimer;

        private IMovementConfig _shipMovementConfig;
        private ISpaceAnchor _spaceAnchor, _enemy;
        private float _weaponRange;
        private bool _needsRotation;
        private BehaviourState _currState;
        private float _currAcceleration;
        private float _rotationValue;
        
        public FrontLineTactic(IMovementConfig movementConfig)
        {
            _shipMovementConfig = movementConfig;
        }


        [Inject]
        private void Setup()
        {
            _gameTimer.AddTickableEvent(Tick);
        }

        private void Tick(float deltatime)
        {
            switch (_currState)
            {
                case BehaviourState.RotateToEnemy:
                    RotateToEnemy(deltatime);
                    break;
                case BehaviourState.MoveToEnemy:
                    MoveToEnemy(deltatime);
                    break;
                case BehaviourState.FireAndBreaking:
                    BreakSpeed(deltatime);
                    break;
            }
        }


        private void RotateToEnemy(float deltaTime)
        {
            var directionToEnemy = _enemy.MovingComponent.Position - _spaceAnchor.MovingComponent.Position;
            var angleToRotate = Vector2.SignedAngle(directionToEnemy, _spaceAnchor.MovingComponent.Direction);
            
            if (Mathf.Abs(angleToRotate) > _shipMovementConfig.RotationSpeed * deltaTime)
            {
                int angleSigh = angleToRotate > 0 ? -1 : 1;
                if (Mathf.Abs(_rotationValue + deltaTime * angleSigh) < 1.0f)
                {
                    _rotationValue += deltaTime * angleSigh;
                    
                }
                _spaceAnchor.MovingComponent.SetRotation(angleSigh);
            }
            else
            {
                if (EnemyInWeaponRange())
                {
                    _currState = BehaviourState.FireAndBreaking;
                    _spaceAnchor.MyWeapon.FireKeyDown();
                }
                else
                {
                    _currState = BehaviourState.MoveToEnemy;
                }
            }
        }


        private void MoveToEnemy(float deltaTime)
        {
            if (EnemyInWeaponRange())
            {
                _currState = BehaviourState.FireAndBreaking;
                _spaceAnchor.MyWeapon.FireKeyDown();
            }
            else
            {
                _spaceAnchor.MovingComponent.SetAcceleration(_currAcceleration);
                if(_currAcceleration < 1.0f)
                    _currAcceleration += deltaTime;
            }
            
        }

        private void BreakSpeed(float deltaTime)
        {
            var shipSpeed = _spaceAnchor.MovingComponent.Speed;

            var accDelta = _shipMovementConfig.AccelerationCoeff * deltaTime;
            if (accDelta > shipSpeed)
            {
                _spaceAnchor.MovingComponent.SetAcceleration(-shipSpeed/deltaTime);
            }
            else
            {
                _spaceAnchor.MovingComponent.SetAcceleration( -1);
            }
            
        }
        
        
        public void SetControllOnShip(ISpaceAnchor spaceAnchor, ISpaceAnchor enemy)
        {
            _spaceAnchor = spaceAnchor;
            _enemy = enemy;
            _weaponRange = _spaceAnchor.MyWeapon.Range;
            _currState = BehaviourState.RotateToEnemy;
        }

        
        
        private bool EnemyInWeaponRange()
        {
            return Vector2.SqrMagnitude(_spaceAnchor.MovingComponent.Position - _enemy.MovingComponent.Position) <
                   _weaponRange * _weaponRange;
        }
        
        
        
        private enum BehaviourState
        {
            None, RotateToEnemy, MoveToEnemy, FireAndBreaking
        }
    }
}