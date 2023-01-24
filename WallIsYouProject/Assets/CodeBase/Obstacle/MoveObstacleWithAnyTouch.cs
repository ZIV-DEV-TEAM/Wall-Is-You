using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObstacleWithAnyTouch : MonoBehaviour,IPointerDownHandler,IDragHandler
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float _speed;
    private Vector2 _startPosition;

    public void OnDrag(PointerEventData eventData)
    {
        Touch touch = Input.GetTouch(0);
        Vector2 direction = touch.position - _startPosition;
        _obstacle.transform.Translate(direction.normalized * _speed*Time.deltaTime, Space.World);
        _startPosition = touch.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        Touch touch = Input.GetTouch(0);
        _startPosition = touch.position;
    }

}
