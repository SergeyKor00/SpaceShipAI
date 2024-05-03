using System;
using GamePlay.Core.Interfaces;
using UnityEngine;

namespace GamePlay.Weapon.Interfaces
{
    public interface IShellAnchor
    {
        int Id { get; }
        
        Vector2 Position { get; }
        
        Vector2 Direction { get; }

        void SetTargetEnemy(ISpaceAnchor spaceAnchor);

        event Action<IShellAnchor> OnAnchorExploded;
    }
}