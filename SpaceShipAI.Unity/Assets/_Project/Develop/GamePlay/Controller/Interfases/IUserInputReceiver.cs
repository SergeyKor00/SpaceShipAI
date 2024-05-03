using UnityEngine;

namespace GamePlay.Controller.Interfases
{
    public interface IUserInputReceiver
    {
        void SetDirection(float rotationAxis);

        void SetAccelerationCoeff(float value);

        void FireKeyDown();

        void FireKeyUp();
    }
}