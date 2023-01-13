using Assets.Scripts.Movment.Joysticks;
using UnityEngine;

public class JoystickForMove : JoysticDefault
{
    public Vector2 Direction => _inputPosition.normalized;
}
