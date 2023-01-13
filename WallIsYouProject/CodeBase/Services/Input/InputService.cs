using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }


        protected static Vector2 SimpleInputAxis()
        {
            return new Vector2(SimpleInput.GetMoveAxis(Horizontal), SimpleMoveInput.GetAxis(Vertical));
        }
    }
}