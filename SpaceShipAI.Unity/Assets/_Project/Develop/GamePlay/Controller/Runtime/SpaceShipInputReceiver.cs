using GamePlay.Controller.Interfases;
using GamePlay.Core.Runtime;
using UnityEngine;
using Zenject;

namespace GamePlay.Controller.Runtime
{
    public class SpaceShipInputReceiver : IUserInputReceiver
    {
        [Inject] private GameEngine _gameEngine;
        
        
        public void SetDirection(float rotationAxis)
        {
            if(!_gameEngine.IsSimulating)
                return;
            
            
            
            _gameEngine.GetTargetEntity().MovingComponent.SetRotation(rotationAxis);
        }

        public void SetAccelerationCoeff(float value)
        {
            if(!_gameEngine.IsSimulating)
                return;
            
            _gameEngine.GetTargetEntity().MovingComponent.SetAcceleration(value);
        }

        public void FireKeyDown()
        {
            if(!_gameEngine.IsSimulating)
                return;
        }

        public void FireKeyUp()
        {
            if(!_gameEngine.IsSimulating)
                return;
        }
    }
}