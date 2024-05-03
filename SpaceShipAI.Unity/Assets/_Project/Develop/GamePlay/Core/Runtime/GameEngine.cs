using GamePlay.Core.Interfaces;
using Zenject;

namespace GamePlay.Core.Runtime
{
    public class GameEngine
    {
        [Inject] private ISpaceAnchorsFactory _spaceAnchorsFactory;
        [Inject] private ISpaceAnchorsStorage _spaceAnchorsStorage;

        private ISpaceAnchor _shipAnchor;
        private bool _isSimulating;


        public bool IsSimulating => _isSimulating;

        public void StartSimulation()
        {
            var spaceShip = _spaceAnchorsFactory.CreateSpaceShip();
            _shipAnchor = spaceShip;
            _spaceAnchorsStorage.AddEntity(spaceShip);

            var spaceStation = _spaceAnchorsFactory.CreatePlatform();
            _spaceAnchorsStorage.AddEntity(spaceShip);
            _isSimulating = true;
            
            _shipAnchor.MyWeapon.SetEnemy(spaceStation);
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