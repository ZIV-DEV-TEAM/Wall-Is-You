using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HintsService : MonoBehaviour
{
    [SerializeField] private GameObject[] _hints;
    private ObstacleService _obstacleService;

    [Inject]
    public void Construct(ObstacleService obstacleService)
    {
        _obstacleService = obstacleService;
    }
    private void Start()
    {
        _obstacleService.AddObserver(OnChanged);
    }

    private void OnChanged(Obstacle obstacle)
    {
        foreach (var hint in _hints)
        {
            hint.transform.position = new Vector3(hint.transform.position.x, hint.transform.position.y, obstacle.transform.position.z);
        }
    }
}
