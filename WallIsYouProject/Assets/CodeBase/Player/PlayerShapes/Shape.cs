using Assets.CodeBase.ObstacleLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    [SerializeField] private PlayerShapes _playerShape;
    private void OnTriggerEnter(Collider other)
    {
         if (other.TryGetComponent(out Obstacle obstacle))
        {
            
            
            obstacle.Lose();
        }
        else if(other.TryGetComponent(out ObstscleCompleted obstacleComplited))
        {
            obstacleComplited.Complite();
            _playerShape.SwitchShape(obstacleComplited.PlayerShapeNumber);

        }
    }
}
