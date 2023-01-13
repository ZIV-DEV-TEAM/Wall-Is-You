using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ObstacleService : MonoBehaviour, IDataPersistence
{
    [SerializeField] private float _delayToDestroyObstacle = 1;   
    [SerializeField] private Transform _hint;   
    [SerializeField] private List<ObstacleMovement> _obstacles = new List<ObstacleMovement>();

    private UIMenu _UIMenu;
    private int _currentObstacle;
    private int _curentlevel;
    public ObstacleMovement CurrentObstacle => _obstacles[_currentObstacle];

    [Inject]
    public void Construct(UIMenu UIMenu)
    {
        _UIMenu = UIMenu;
    }
    private void Start()
    {
        _obstacles[_currentObstacle].IsActive = true;
        _curentlevel = SceneManager.GetActiveScene().buildIndex;
        _curentlevel = _curentlevel < 1 ? 1 : _curentlevel;
    }
    public void SwitchObstacleToNext()
    {
        if (!_obstacles[0].IsActive)
            return;
        _obstacles[_currentObstacle].IsActive = false;
        StartCoroutine(DestroyObstacle());
        if (_obstacles.Count != 1 && !_obstacles[_obstacles.Count-1].IsActive)
        {
            ActivateObstacle();
            MoveHint();
        }
    }
    public void ActivateObstacle()
    {
        _currentObstacle++;
        _obstacles[_currentObstacle].IsActive = true;
    }
    private void MoveHint()
    {
        _hint.position = new Vector3(_hint.position.x, _hint.position.y, _obstacles[_currentObstacle].transform.position.z);
    }
    IEnumerator DestroyObstacle()
    {
        if (_delayToDestroyObstacle == 0)
        {
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(_delayToDestroyObstacle);
        }
        if (_obstacles.Count==1&&!_obstacles[_obstacles.Count - 1].IsActive)
        {
            _curentlevel++;
            _UIMenu.ActiveMenuWin();
            yield break;
        }
        _currentObstacle--;
        var obstacleToRemove = _obstacles[_currentObstacle];
        _obstacles.Remove(obstacleToRemove);
        Destroy(obstacleToRemove.gameObject);
    }

    public void LoadData(GameData data)
    {
        
    }

    public void SaveData(GameData data)
    {
        data.LevelNumber = _curentlevel;
    }
}
