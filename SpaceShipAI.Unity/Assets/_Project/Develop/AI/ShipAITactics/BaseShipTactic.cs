using GamePlay.Controller.Interfases;
using GamePlay.Core.Interfaces;
using GamePlay.Movement.Interfaces;
using UnityEngine;
using Zenject;

namespace AI.ShipAITactics
{
    public abstract class BaseShipTactic
    {
        [Inject] protected IGameTimer _gameTimer;
        protected IShipMovementController _movementController;
        protected IMovementConfig _shipMovementConfig;
        protected ISpaceAnchor _spaceAnchor;
        protected ISpaceAnchor _enemy;
        protected float _weaponRange;

        protected BaseShipTactic(IShipMovementController movementController, IMovementConfig shipMovementConfig)
        {
            _movementController = movementController;
            _shipMovementConfig = shipMovementConfig;
        }

        protected abstract void Tick(float deltatime);


        protected bool EnemyInWeaponRange()
        {
            return Vector2.SqrMagnitude(_spaceAnchor.MovingComponent.Position - _enemy.MovingComponent.Position) <
                   _weaponRange * _weaponRange;
        }
    }
}