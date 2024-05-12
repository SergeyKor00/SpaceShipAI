using GamePlay.Controller.Runtime;
using GamePlay.Core.Interfaces;
using GamePlay.Movement.Interfaces;
using Zenject;

namespace AI.ShipAITactics
{
    public class ShipAiFactory : ITacticFactory
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private IMovementConfig _movementConfig;
        
        public IShipAITactic CreateTactic(ISpaceAnchor spaceAnchor)
        {
            var movementController = new ShipMovementController(_movementConfig, spaceAnchor.MovingComponent);
            _diContainer.Inject(movementController);
            
            var tactic = new FrontLineTactic(_movementConfig, movementController);
            _diContainer.Inject(tactic);
            return tactic;
        }
    }
}