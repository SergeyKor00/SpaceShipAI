using AI.ShipAITactics;
using GamePlay.Core.Interfaces;
using GamePlay.Movement.Interfaces;
using UnityEngine;
using Zenject;

namespace GamePlay.Core.Runtime
{
    public class GameEngine
    {
        [Inject] private ISpaceAnchorsFactory _spaceAnchorsFactory;
        [Inject] private ISpaceAnchorsStorage _spaceAnchorsStorage;
        [Inject] private ITacticFactory _tacticFactory;
        
        
        private ISpaceAnchor _shipAnchor;
        private bool _isSimulating;


        public bool IsSimulating => _isSimulating;

        public void StartSimulation(bool useAiPlayer)
        {
            var spaceShip = _spaceAnchorsFactory.CreateSpaceShip();
            _shipAnchor = spaceShip;
            _spaceAnchorsStorage.AddEntity(spaceShip);

            var spaceStation = _spaceAnchorsFactory.CreatePlatform();
            _spaceAnchorsStorage.AddEntity(spaceShip);
            _isSimulating = true;
            spaceStation.MyHull.OnAnchorReceiveFatalDamage += OnStationDestoryed;
            _shipAnchor.MyWeapon.SetEnemy(spaceStation);

            if (useAiPlayer)
            {
                var frontLineAI = _tacticFactory.CreateTactic(_shipAnchor);
                frontLineAI.SetControllOnShip(_shipAnchor, spaceStation);
            }
        }

        private void OnStationDestoryed(ISpaceAnchor anchor)
        {
            Debug.Log("GameOver");
            StopSimulation();
        }
        
        public void StopSimulation()
        {
            _spaceAnchorsStorage.ClearStorage();
            _isSimulating = false;
        }

        public ISpaceAnchor GetTargetEntity()
        {
            return _shipAnchor;
        }
    }
}