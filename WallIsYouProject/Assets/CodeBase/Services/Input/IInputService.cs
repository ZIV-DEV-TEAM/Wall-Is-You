using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public interface IInputService
    {
        Vector3 Direction { get; }
        Vector3 RotateDirection { get; }
    }
}