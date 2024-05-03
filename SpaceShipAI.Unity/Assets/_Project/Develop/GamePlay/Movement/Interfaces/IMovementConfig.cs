using UnityEngine;

namespace GamePlay.Movement.Interfaces
{
    public interface IMovementConfig
    {
        float MovingSpeed { get; }
        
        float RotationSpeed { get; }
        
        Vector2 ShipStartPosition { get; }
        
        Vector2 StationStartPosition { get; }
        float AccelerationCoeff { get; }
    }
}