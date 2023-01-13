using UnityEngine;

namespace Assets.CodeBase.ObstacleLogic.Arrows
{
    public class RotateDirection : MonoBehaviour
    {
        [SerializeField] private RotateWithTheArrows[] arrows;
        public Vector3 Direction => GetRotateDirection();
        public Vector3 GetRotateDirection()
        {
            foreach (RotateWithTheArrows arrow in arrows)
            {
                if (arrow.RotateDirection != Vector3.zero)
                {
                    return arrow.RotateDirection;
                }
            }
            return Vector3.zero;
        }
    }
}