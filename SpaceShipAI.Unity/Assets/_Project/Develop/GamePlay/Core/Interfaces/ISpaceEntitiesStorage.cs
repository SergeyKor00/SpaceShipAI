namespace GamePlay.Core.Interfaces
{
    public interface ISpaceAnchorsStorage
    {
        void AddEntity(ISpaceAnchor spaceAnchor);

        ISpaceAnchor GetAnchorById(int id);

        ISpaceAnchor[] GetAllEntities();

        void ClearStorage();
    }
}