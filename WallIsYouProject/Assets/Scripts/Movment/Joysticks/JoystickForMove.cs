using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickForMove : JoysticDefault
{
    public Vector2 VectorMove => _inputPosition.normalized;
    [SerializeField] private ObstacleManager _obstacleManager;
    [SerializeField] private float _speed;
    private void Update()
    {
        if (VectorMove == Vector2.zero)
            return;
        _obstacleManager.CurrentObstacle.transform.Translate(VectorMove * _speed*Time.deltaTime,Space.World);
    }
}
