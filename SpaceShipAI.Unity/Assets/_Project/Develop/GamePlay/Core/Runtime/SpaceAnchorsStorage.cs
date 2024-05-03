using System.Collections.Generic;
using GamePlay.Core.Interfaces;

namespace GamePlay.Core.Runtime
{
    public class SpaceAnchorsStorage : ISpaceAnchorsStorage
    {
       
        
        public void AddEntity(ISpaceAnchor spaceAnchor)
        {
            
        }

        public ISpaceAnchor GetAnchorById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ISpaceAnchor[] GetAllEntities()
        {
            throw new System.NotImplementedException();
        }

        public void ClearStorage()
        {
            
        }
    }
}