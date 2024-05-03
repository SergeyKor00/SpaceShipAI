using System;
using GamePlay.Core.Interfaces;
using GamePlay.Weapon.Interfaces;
using UnityEngine;
using Zenject;

namespace GamePlay.Weapon.Runtime
{
    public class SimpleShell : IShellAnchor
    {
        [Inject] private IGameTimer _gameTimer;
        
        private Vector2 _direction;
        private float _lifeTime;
        private ISpaceAnchor _targetEnemy;
        private  Vector2 _position;
        private float _speed;
        

        public SimpleShell(int id,Vector2 position, float lifeTime, float speed)
        {
            Id = id;
            _position = position;
            _lifeTime = lifeTime;
            _speed = speed;
        }

        public int Id { get; }
        public Vector2 Position => _position;

        public Vector2 Direction => _direction;
        
        

        [Inject]
        private void Setup()
        {
            _gameTimer.AddTickableEvent(Tick);
        }

        private void Tick(float deltatime)
        {
            _position += _direction * deltatime * _speed;
            if (Vector2.SqrMagnitude(_position - _targetEnemy.MovingComponent.Position) < 0.01f)
            {
                Debug.Log("Hit enemy");
                DestoryShell();
                return;
            }
            
            _lifeTime -= deltatime;
            if (_lifeTime <= 0.0f)
            {
                Debug.Log("Life time ended");
                DestoryShell();
            }
            
        }

        private void DestoryShell()
        {
            OnAnchorExploded?.Invoke(this);
            _gameTimer.RemoveTickableEvent(Tick);
        }
        

        public void SetTargetEnemy(ISpaceAnchor spaceAnchor)
        {
            _targetEnemy = spaceAnchor;
            _direction = (spaceAnchor.MovingComponent.Position - Position).normalized;
        }

        public event Action<IShellAnchor> OnAnchorExploded;
    }
}