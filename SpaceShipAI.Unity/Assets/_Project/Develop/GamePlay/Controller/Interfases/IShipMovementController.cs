using System;
using UnityEngine;

namespace GamePlay.Controller.Interfases
{
    public interface IShipMovementController
    {
        void SetTargetSpeed(float targetValue, Action onComplite = null);
        void RotateToDirection(Vector2 direction, Action onComplite = null);
    }
}