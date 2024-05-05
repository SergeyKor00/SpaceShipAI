using UnityEngine;

namespace GamePlay.Movement.Interfaces
{
    public interface IMovingComponent
    {
        ref Vector2 Position { get; }
        
        ref Vector2 Direction { get; }
        
        float Speed { get; }

        void SetRotation(float value);

        void SetAcceleration(float value);
    }
}