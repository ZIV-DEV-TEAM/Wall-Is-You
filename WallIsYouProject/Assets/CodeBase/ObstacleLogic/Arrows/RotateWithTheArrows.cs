using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.CodeBase.ObstacleLogic.Arrows
{
    public class RotateWithTheArrows : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

    {
        [SerializeField] private bool _isClockwise;
        private Vector3 _rotateDirection;
        public Vector3 RotateDirection => _rotateDirection;
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isClockwise)
            {
                _rotateDirection = Vector3.back;
                //_obstacleManager.CurrentObstacle.transform.Rotate(-Vector3.forward* _speed);
            }
            else
            {
                _rotateDirection = Vector3.forward;
                //_obstacleManager.CurrentObstacle.transform.Rotate(Vector3.forward * _speed);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _rotateDirection = Vector3.zero;
        }
    }
}