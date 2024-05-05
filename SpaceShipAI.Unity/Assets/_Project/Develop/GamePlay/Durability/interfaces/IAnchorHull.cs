using System;
using GamePlay.Core.Interfaces;

namespace GamePlay.Durability.interfaces
{
    public interface IAnchorHull
    {
        int Health { get; }
        
        float ContactRadius { get; }

        void Damage(int value);

        event Action<ISpaceAnchor> OnAnchorReceiveFatalDamage;
    }
}