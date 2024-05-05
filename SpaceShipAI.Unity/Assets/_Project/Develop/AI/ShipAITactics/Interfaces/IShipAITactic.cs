using GamePlay.Core.Interfaces;

namespace AI.ShipAITactics
{
    public interface IShipAITactic
    {
        void SetControllOnShip(ISpaceAnchor spaceAnchor, ISpaceAnchor enemy);
    }
}