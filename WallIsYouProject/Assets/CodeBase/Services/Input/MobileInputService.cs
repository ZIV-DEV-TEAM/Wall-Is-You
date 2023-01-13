using Assets.CodeBase.Joysticks;
using Assets.CodeBase.ObstacleLogic.Arrows;
using System;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Services.Input
{
    public class MobileInputService : IInputService
    {
        private JoystickForMove _joystickForMove;
        private RotateDirection _rotateDirection;
        public MobileInputService( JoystickForMove joystickForMove, RotateDirection rotateDirection)
        {
            _joystickForMove = joystickForMove;
            _rotateDirection = rotateDirection;
        }

        public Vector3 Direction => _joystickForMove.Direction;
        public Vector3 RotateDirection => _rotateDirection.Direction;

    }
}