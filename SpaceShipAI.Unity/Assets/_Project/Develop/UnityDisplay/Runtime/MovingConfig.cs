using GamePlay.Movement.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityDisplay.Runtime
{
    [CreateAssetMenu(fileName = "MovingConfig", menuName = "Configs/MovingConfig", order = 0)]
    public class MovingConfig : ScriptableObject, IMovementConfig
    {
        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _accelerationCoeff;
        [SerializeField] private Vector2 _shipPosition, _stationPosition;
        
        public float MovingSpeed => _movingSpeed;
        public float RotationSpeed => _rotationSpeed;

        public float AccelerationCoeff => _accelerationCoeff;

        public Vector2 ShipStartPosition => _shipPosition;
        public Vector2 StationStartPosition => _stationPosition;
        
    }
}