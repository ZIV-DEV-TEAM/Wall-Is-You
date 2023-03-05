using UnityEngine;
using Zenject;
using UI;

namespace Assets.CodeBase.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIMenu _UIMenu;
        public override void InstallBindings()
        {
            BindUIMenu();
        }

        private void BindUIMenu()
        {
            Container
               .Bind<UIMenu>()
               .FromInstance(_UIMenu)
               .AsSingle()
               .NonLazy();
        }
    }
}