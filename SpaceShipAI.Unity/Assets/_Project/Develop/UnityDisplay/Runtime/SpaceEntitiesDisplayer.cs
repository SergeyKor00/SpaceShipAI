using System;
using System.Collections.Generic;
using GamePlay.Core.Interfaces;
using GamePlay.Weapon.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityDisplay.Runtime
{
    public class SpaceEntitiesDisplayer : MonoBehaviour
    {
        [SerializeField] private GameObject _spaceShipPrefab, _spaceStationPrefab;
        [SerializeField] private GameObject _shellPrefab;
        
        private Transform _spaceShipTransform, _spaceStationTransform;
        private ISpaceAnchor _spaceShipAnchor, _stationAnchor;
        private Dictionary<int, AnchorToGameObjectComparer> _shellsToDisplay = new Dictionary<int, AnchorToGameObjectComparer>();
        
        
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
            _spaceShipTransform.rotation = Quaternion.LookRotation(_spaceShipAnchor.MovingComponent.Direction, Vector3.forward);

            _spaceStationTransform.position = _stationAnchor.MovingComponent.Position;
            //_spaceStationTransform.rotation = _stationAnchor.MovingComponent.Direction;

            foreach (var shells in _shellsToDisplay.Values)
            {
                shells.TargetObject.transform.position = shells.ShellAnchor.Position;
                shells.TargetObject.transform.rotation = Quaternion.LookRotation(shells.ShellAnchor.Direction, Vector3.forward);
            }
        }

        public void AddShell(IShellAnchor shell)
        {
            shell.OnAnchorExploded += ShellOnOnAnchorExploded;
            var shellInstance = Instantiate(_shellPrefab);
            _shellsToDisplay.Add(shell.Id, new AnchorToGameObjectComparer()
            {
                ShellAnchor = shell, TargetObject = shellInstance
            });
        }

        private void ShellOnOnAnchorExploded(IShellAnchor shellAnchor)
        {
            shellAnchor.OnAnchorExploded -= ShellOnOnAnchorExploded;
            
            Destroy(_shellsToDisplay[shellAnchor.Id].TargetObject);
            
            _shellsToDisplay.Remove(shellAnchor.Id);
        }
        
        private class AnchorToGameObjectComparer
        {
            public IShellAnchor ShellAnchor;
            public GameObject TargetObject;
        }
    }
    
}