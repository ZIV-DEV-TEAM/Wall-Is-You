using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    private const int _obstacleContinue = 3;
    [SerializeField] private ObstacleService _obstacleService;
    private UIMenu _UIMenu;
    private Score _score;

    [Inject]
    public void Construct(UIMenu UIMenu, Score score)
    {
        _UIMenu = UIMenu;
        _score = score;
    }
    public void Lose()
    {
        if (_score.Value < _obstacleContinue)
        {
            _UIMenu.ActiveMenuLose();
        }
        else
        {
            _UIMenu.ActiveMenuLoseWithContinue();
        }
    }
}
