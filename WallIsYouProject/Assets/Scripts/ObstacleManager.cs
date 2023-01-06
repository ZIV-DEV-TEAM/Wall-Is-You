using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles = new List<GameObject>();
    [SerializeField] private GameManager _gameManager;
    private GameObject _currentObstacle;
    public GameObject CurrentObstacle => _currentObstacle;
    private void Start()
    {
        _currentObstacle = _obstacles[0];
    }
    public void SwitchObstacleToNext()
    {
        _currentObstacle.SetActive(false);
        _obstacles.Remove(_currentObstacle);
        if (_obstacles.Count ==0)
        {
            _gameManager.Win();
            return;
        }
        _currentObstacle = _obstacles[0];
    }
}
