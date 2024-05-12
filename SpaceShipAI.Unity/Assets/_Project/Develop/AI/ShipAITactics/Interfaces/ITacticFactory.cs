using GamePlay.Core.Interfaces;

namespace AI.ShipAITactics
{
    public interface ITacticFactory
    {
        IShipAITactic CreateTactic(ISpaceAnchor spaceAnchor);
    }
}