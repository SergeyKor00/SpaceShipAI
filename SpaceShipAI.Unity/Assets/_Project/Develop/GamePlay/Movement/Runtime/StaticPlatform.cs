using GamePlay.Movement.Interfaces;
using UnityEngine;

namespace GamePlay.Movement.Runtime
{
    public class StaticPlatform : IMovingComponent
    {
        private Vector2 _myPosition;
        private Quaternion _myRotation;
        
        public ref Vector2 Position => ref _myPosition;

        public ref Quaternion Rotation => ref _myRotation;

        public  float Acceleration =>  0.0f;


        public StaticPlatform(Vector2 myPosition)
        {
            _myPosition = myPosition;
        }


        public void SetRotation(float value)
        {
            
        }

        public void SetAcceleration(float value)
        {
            
        }
    }
}