using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateWithTheArrows : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    [SerializeField] private ObstacleManager _obstacleManager;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isClockwise;
    private bool _isRotating;
    public void OnPointerDown(PointerEventData eventData)
    {
        _isRotating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isRotating = false;
    }

    private void Update()
    {
        if(!_isRotating)
            return;
        if (_isClockwise)
        {
            _obstacleManager.CurrentObstacle.transform.Rotate(-Vector3.forward* _speed);
        }
        else
        {
            _obstacleManager.CurrentObstacle.transform.Rotate(Vector3.forward * _speed);
        }
    }

}
