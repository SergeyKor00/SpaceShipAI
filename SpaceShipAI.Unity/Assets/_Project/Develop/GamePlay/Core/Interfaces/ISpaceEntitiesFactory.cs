namespace GamePlay.Core.Interfaces
{
    public interface ISpaceAnchorsFactory
    {
        ISpaceAnchor CreateSpaceShip();

        ISpaceAnchor CreatePlatform();
    }
}