using GamePlay.Core.Runtime;
using UnityEngine;
using Zenject;

namespace UnityDisplay.Runtime
{
    public class GameLauncher : MonoBehaviour
    {
        [Inject] private GameEngine _gameEngine;


        [SerializeField] private bool _useAiToPlay;
        
        private void Start()
        {
            _gameEngine.StartSimulation(_useAiToPlay);
            GetComponent<InputHandler>().enabled = !_useAiToPlay;
        }
    }
}