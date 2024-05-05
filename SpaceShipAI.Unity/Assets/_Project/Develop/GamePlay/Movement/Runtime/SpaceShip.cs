using GamePlay.Core.Interfaces;
using GamePlay.Movement.Interfaces;
using UnityEngine;
using Zenject;

namespace GamePlay.Movement.Runtime
{
    public class SpaceShip : IMovingComponent
    {
        [Inject] private IGameTimer _gameTimer;
        [Inject] private IMovementConfig  _movementConfig;
        
        private Vector2 _myPosition;
        private Quaternion _myRotation;
        private float _currSpeed;
        private float _currRotation;
        
        private Vector2 _targetDirection;
        private float _lastFrameDeltaTime;
        public ref Vector2 Position => ref _myPosition;
        public ref Vector2 Direction => ref _targetDirection;
        public float Speed => _currSpeed;


        [Inject]
        private void Setup()
        {
            _gameTimer.AddTickableEvent(UpdatePosition);
            _myPosition = _movementConfig.ShipStartPosition;
            _myRotation = Quaternion.LookRotation(Vector3.up, Vector3.forward);
            _targetDirection = Vector2.right;
        }

        
        
        public void SetRotation(float value)
        {
            if(value == 0.0f)
            {
                return;
            }

            _currRotation += value * _movementConfig.RotationSpeed * _lastFrameDeltaTime;
            _targetDirection = new Vector2(Mathf.Cos(_currRotation), Mathf.Sin(_currRotation));
            _myRotation = Quaternion.LookRotation(_targetDirection, Vector3.forward);
        }

        public void SetAcceleration(float value)
        {
            
            if(Mathf.Abs(_currSpeed + value * _movementConfig.AccelerationCoeff * _lastFrameDeltaTime) < _movementConfig.MovingSpeed)
                _currSpeed += value * _movementConfig.AccelerationCoeff * _lastFrameDeltaTime;
            
        }

        void UpdatePosition(float deltaTime)
        {
            _lastFrameDeltaTime = deltaTime;
            _myPosition += _targetDirection * _currSpeed * deltaTime;
            
        }
    }
}