using GamePlay.Movement.Interfaces;
using Zenject;

namespace AI.ShipAITactics
{
    public class ShipAiFactory : ITacticFactory
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private IMovementConfig _movementConfig;
        
        public IShipAITactic CreateTactic()
        {
            var tactic = new FrontLineTactic(_movementConfig);
            _diContainer.Inject(tactic);
            return tactic;
        }
    }
}