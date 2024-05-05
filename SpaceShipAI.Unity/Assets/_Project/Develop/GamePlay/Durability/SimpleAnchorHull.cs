using System;
using GamePlay.Core.Interfaces;
using GamePlay.Durability.interfaces;
using UnityEngine;

namespace GamePlay.Durability
{
    public class SimpleAnchorHull : IAnchorHull
    {
        private int _health;
        private float _contactRadius;

        private ISpaceAnchor _spaceAnchor;

        public SimpleAnchorHull(IHullConfig config, ISpaceAnchor myAcnhor)
        {
            _health = config.StartHealth;
            _contactRadius = config.ContactRadius;
            _spaceAnchor = myAcnhor;
        }

        public int Health => _health;

        public float ContactRadius => _contactRadius;
        
        public event Action<ISpaceAnchor> OnAnchorReceiveFatalDamage;
        
        public void Damage(int value)
        {
            _health -= value;
            if (_health <= 0)
            {
                Debug.Log("Destroy");
                OnAnchorReceiveFatalDamage?.Invoke(_spaceAnchor);
            }
        }

        
    }
}