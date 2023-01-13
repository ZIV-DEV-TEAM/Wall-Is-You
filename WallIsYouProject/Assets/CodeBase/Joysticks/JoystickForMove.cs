using UnityEngine;

namespace Assets.CodeBase.Joysticks
{
    public class JoystickForMove : JoysticDefault
    {
        public Vector2 Direction => _inputPosition.normalized;
    }
}