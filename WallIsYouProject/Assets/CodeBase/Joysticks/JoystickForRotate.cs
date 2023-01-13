using UnityEngine;

namespace Assets.CodeBase.Joysticks
{
    public class JoystickForRotate : JoysticDefault
    {
        public Vector2 VectorRotate => _inputPosition.normalized;

        [SerializeField] private GameObject _obstacle;
        [SerializeField] private float _speed;

        private Vector2 _lastPosition;
        private void Update()
        {
            if (VectorRotate == Vector2.zero)
                return;
            if (VectorRotate == _lastPosition)
            {
                return;
            }
            Vector2 offset = VectorRotate - _lastPosition;
            if (Mathf.Abs(VectorRotate.x) > Mathf.Abs(VectorRotate.y))
            {
                if (VectorRotate.x > 0)
                {
                    _obstacle.transform.Rotate(new Vector3(0, 0, offset.y) * _speed);
                }
                else
                {
                    _obstacle.transform.Rotate(new Vector3(0, 0, -offset.y) * _speed);
                }
            }
            else
            {
                if (VectorRotate.y > 0)
                {
                    _obstacle.transform.Rotate(new Vector3(0, 0, -offset.x) * _speed);
                }
                else
                {
                    _obstacle.transform.Rotate(new Vector3(0, 0, offset.x) * _speed);
                }
            }
            _lastPosition = VectorRotate;
        }

    }
}