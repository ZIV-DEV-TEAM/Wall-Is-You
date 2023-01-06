using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuWin;
    [SerializeField] private AudioSource _audioSourceWin;
    [SerializeField] private GameObject _menuLose;
    [SerializeField] private AudioSource _audioSourceLose;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Win()
    {
        Time.timeScale = 0;
        Handheld.Vibrate();
        _menuWin.SetActive(true);
        _audioSourceWin.Play();
    } 
    public void Lose()
    {
        Time.timeScale = 0;
        Handheld.Vibrate();
        _menuLose.SetActive(true);
        _audioSourceLose.Play();
    }
}
