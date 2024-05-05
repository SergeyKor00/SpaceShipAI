using GamePlay.Core.Interfaces;
using GamePlay.Weapon;
using GamePlay.Weapon.Interfaces;
using GamePlay.Weapon.Runtime;
using Zenject;

namespace UnityDisplay.Runtime
{
    public class PlayModeShellsFactory : IShellsFactory
    {
        [Inject] private SpaceEntitiesDisplayer _entitiesDisplayer;
        [Inject] private DiContainer  _diContainer;
        [Inject] private IWeaponConfig _weaponConfig;
        
        private int _lastShellId;
        public IShellAnchor CreateShell(WeaponType weaponType, ISpaceAnchor anchor)
        {
            _lastShellId++;
            switch (weaponType)
            {
                default:
                    var creatingData = new ShellCreatingData
                    {
                        LifeTime = _weaponConfig.MissleLifeTime,
                        Position = anchor.MovingComponent.Position,
                        Power = _weaponConfig.StartPower,
                        Speed = _weaponConfig.MissleSpeed
                    };
                    
                    var shell = new SimpleShell(_lastShellId, creatingData);
                    _diContainer.Inject(shell);
                    _entitiesDisplayer.AddShell(shell);
                    
                    return shell;
            }

           
        }
    }
}