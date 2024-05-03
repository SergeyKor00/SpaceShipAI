using System;
using GamePlay.Core.Interfaces;
using UnityEngine;

namespace UnityDisplay.Runtime
{
    public class SpaceEntitiesDisplayer : MonoBehaviour
    {
        [SerializeField] private GameObject _spaceShipPrefab, _spaceStationPrefab;

        private Transform _spaceShipTransform, _spaceStationTransform;
        private ISpaceAnchor _spaceShipAnchor, _stationAnchor;
        
        
        public void AddSpaceShip(ISpaceAnchor anchor)
        {
            _spaceShipAnchor = anchor;
            _spaceShipTransform = Instantiate(_spaceShipPrefab).transform;
            
        }

        public void AddPlatform(ISpaceAnchor anchor)
        {
            _stationAnchor = anchor;
            _spaceStationTransform = Instantiate(_spaceStationPrefab).transform;
        }

        private void Update()
        {
            _spaceShipTransform.position = _spaceShipAnchor.MovingComponent.Position;
            _spaceShipTransform.rotation = _spaceShipAnchor.MovingComponent.Rotation;

            _spaceStationTransform.position = _spaceShipAnchor.MovingComponent.Position;
            _spaceStationTransform.rotation = _spaceShipAnchor.MovingComponent.Rotation;
        }
    }
}