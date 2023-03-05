using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UI;

public class Obstacle : MonoBehaviour
{
    private const int _obstacleContinue = 3;
    [SerializeField] private ObstacleService _obstacleService;
    private UIMenu _UIMenu;
    private Score _score;
    private LeaderboardController _leaderboardController;
    
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
            _UIMenu.StopGame();
            _UIMenu.Leaderboard();
            _leaderboardController.SubmitScoreRoutine(_score.Value);
        }
        else
        {
            _UIMenu.ActiveMenuLoseWithContinue();
        }
    }
}
