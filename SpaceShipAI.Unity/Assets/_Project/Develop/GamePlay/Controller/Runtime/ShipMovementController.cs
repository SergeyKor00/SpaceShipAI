using System;
using GamePlay.Controller.Interfases;
using GamePlay.Core.Interfaces;
using GamePlay.Movement.Interfaces;
using UnityEngine;
using Zenject;

namespace GamePlay.Controller.Runtime
{
    public class ShipMovementController : IShipMovementController
    {
        [Inject] private IGameTimer _gameTimer;
        
        private IMovementConfig _shipMovementConfig;
        
        private Vector2 _targetDirection;
        private bool _needRotate;
        private Action _onRotationCompleteAction;

        private bool _needChangeSpeed;
        private float _targetSpeed;
        private Action _onSpeedChangedAction;
        
        public ShipMovementController(IMovementConfig shipMovementConfig, IMovingComponent myMovingComponent)
        {
            _shipMovementConfig = shipMovementConfig;
            _myMovingComponent = myMovingComponent;
        }

        private IMovingComponent _myMovingComponent;

        [Inject]
        private void Setup()
        {
            _gameTimer.AddTickableEvent(Tick);
        }

        private void Tick(float deltatime)
        {
            if (_needRotate)
            {
                RotateToDirection(deltatime);
            }

            if (_needChangeSpeed)
            {
                ChangeSpeed(deltatime);
            }
        }


        private void RotateToDirection(float deltaTime)
        {
            var angleToRotate = Vector2.SignedAngle(_targetDirection, _myMovingComponent.Direction);
            
            if (Mathf.Abs(angleToRotate) > _shipMovementConfig.RotationSpeed * deltaTime)
            {
                int angleSigh = angleToRotate > 0 ? -1 : 1;
                _myMovingComponent.SetRotation(angleSigh);
            }
            else
            {
                _onRotationCompleteAction?.Invoke();
                _needRotate = false;
            }
        }

        private void ChangeSpeed(float deltaTime)
        {
            var speedDelta = _shipMovementConfig.AccelerationCoeff * deltaTime;
            int accSign = _targetSpeed > _myMovingComponent.Speed ? 1 : -1;

            var targetSpeedDelta = Mathf.Abs(_targetSpeed - _myMovingComponent.Speed);
            if (targetSpeedDelta <  speedDelta)
            {
                _myMovingComponent.SetAcceleration(accSign * targetSpeedDelta / speedDelta);
                _needChangeSpeed = false;
                _onSpeedChangedAction?.Invoke();
                _onSpeedChangedAction = null;
            }
            else
            {
                _myMovingComponent.SetAcceleration(accSign);
            }

        }

        
        public void SetTargetSpeed(float targetValue, Action onComplite)
        {
            _targetSpeed = targetValue;
            _needChangeSpeed = true;
            _onSpeedChangedAction = onComplite;
        }


        public void RotateToDirection(Vector2 direction, Action onComplite)
        {
            _needRotate = true;
            _targetDirection = direction;
            _onRotationCompleteAction = onComplite;
        }
    }
}