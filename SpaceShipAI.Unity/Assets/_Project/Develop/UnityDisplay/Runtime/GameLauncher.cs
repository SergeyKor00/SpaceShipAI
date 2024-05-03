using System;
using GamePlay.Core.Runtime;
using UnityEngine;
using Zenject;

namespace UnityDisplay.Runtime
{
    public class GameLauncher : MonoBehaviour
    {
        [Inject] private GameEngine _gameEngine;
        
        private void Start()
        {
            _gameEngine.StartSimulation();
        }
    }
}