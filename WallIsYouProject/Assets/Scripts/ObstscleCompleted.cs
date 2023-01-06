using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstscleCompleted : MonoBehaviour
{
    [SerializeField] private float _deviationOfDisappearance;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _notificationScore;
    [SerializeField] private ObstacleManager _obstacleManager;
    [SerializeField] private PlayerShapes _playerShapes;
    [SerializeField] private Shape _shapeType;
    [SerializeField] private AudioSource _audioSource;
    private void Update()
    {
        if (_obstacleManager.CurrentObstacle != this.gameObject)
            return;
        if (_player.transform.position.z + _deviationOfDisappearance > this.transform.position.z)
        {
            Score.instance.Add(1);
            _audioSource.Play();
            Handheld.Vibrate();
            _playerShapes.SwitchShape(_shapeType);
            _notificationScore.SetActive(true);
            _obstacleManager.SwitchObstacleToNext();
        }
    }
}
