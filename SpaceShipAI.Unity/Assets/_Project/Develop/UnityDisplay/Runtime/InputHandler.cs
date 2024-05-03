using System;
using GamePlay.Controller.Interfases;
using UnityEngine;
using Zenject;

namespace UnityDisplay.Runtime
{
    public class InputHandler : MonoBehaviour
    {
        [Inject] private IUserInputReceiver _inputReceiver;

        private void Update()
        {
            var axis = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            
            
            _inputReceiver.SetDirection(-axis);
            _inputReceiver.SetAccelerationCoeff(vertical);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _inputReceiver.FireKeyDown();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                _inputReceiver.FireKeyUp();
            }
        }
    }
}