using UnityEngine;

namespace GamePlay.Movement.Interfaces
{
    public interface IMovingComponent
    {
        ref Vector2 Position { get; }
        
        ref Quaternion Rotation { get; }
        

        void SetRotation(float value);

        void SetAcceleration(float value);
    }
}