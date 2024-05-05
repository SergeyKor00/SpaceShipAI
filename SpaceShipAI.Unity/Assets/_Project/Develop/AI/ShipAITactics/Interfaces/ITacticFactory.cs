namespace AI.ShipAITactics
{
    public interface ITacticFactory
    {
        IShipAITactic CreateTactic();
    }
}