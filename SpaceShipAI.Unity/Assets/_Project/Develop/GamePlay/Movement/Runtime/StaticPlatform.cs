using GamePlay.Movement.Interfaces;
using UnityEngine;

namespace GamePlay.Movement.Runtime
{
    public class StaticPlatform : IMovingComponent
    {
        private Vector2 _myPosition;
        private Vector2 _myRotation;
        
        public ref Vector2 Position => ref _myPosition;

        public ref Vector2 Direction => ref _myRotation;

        public  float Speed =>  0.0f;


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