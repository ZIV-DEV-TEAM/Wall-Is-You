using Assets.CodeBase.Joysticks;
using Assets.CodeBase.ObstacleLogic.Arrows;
using Assets.CodeBase.Services.Input;
using CodeBase.Infrastructure;
using System.IO;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Installers
{
    public class MovementInstaller : MonoInstaller
    {
        private const string InputPath = "Prefabs/Input";
        private JoystickForMove _joystickForMove;
        private RotateDirection _rotateDirection;

        public override void InstallBindings()
        {
            BindInputDispley();
            BindMobileInputService();
        }

        private void BindInputDispley()
        {
            var prefab = Resources.Load<GameObject>(InputPath);
            InputDisplay inputDisplay = Container.InstantiatePrefabForComponent<InputDisplay>(prefab);
            DontDestroyOnLoad(inputDisplay);
            Container
                .Bind<InputDisplay>()
                .FromInstance(inputDisplay)
                .AsSingle();
            _joystickForMove = inputDisplay._joysticForMove;
            _rotateDirection = inputDisplay._rotateDirection;
        }

        private void BindMobileInputService()
        {
            Container
                .Bind<IInputService>()
                .To<MobileInputService>()
                .AsSingle()
                .WithArguments(_joystickForMove, _rotateDirection);
        }

    }
}