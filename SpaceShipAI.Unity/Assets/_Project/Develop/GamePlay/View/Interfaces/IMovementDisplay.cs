using UnityEngine;

namespace GamePlay.View.Interfaces
{
    public interface IMovementDisplay
    {
        ref Vector2 Position { get; }
        
        ref Quaternion Rotation { get; }
        
        ref float Acceleration { get; }
    }
}