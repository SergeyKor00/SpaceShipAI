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
        
        private int _lastShellId;
        public IShellAnchor CreateShell(WeaponType weaponType, ISpaceAnchor anchor)
        {
            _lastShellId++;
            switch (weaponType)
            {
                default:
                    var shell = new SimpleShell(_lastShellId, anchor.MovingComponent.Position, 2.0f, 10.0f);
                    _diContainer.Inject(shell);
                    _entitiesDisplayer.AddShell(shell);
                    
                    return shell;
            }

           
        }
    }
}