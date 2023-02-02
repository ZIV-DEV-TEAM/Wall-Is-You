using CodeBase.Infrastructure;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Zenject;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private GameObject _menuLoseWithContinue;
    [SerializeField] private GameObject _menuWin;
    [SerializeField] private GameObject _menuLose;
    private GameStateMachine _state;
    [Inject]
    public void Construct(GameStateMachine state)
    {
        _state = state;
    }
    public void ToggleVibration(bool enable)
    {
        Vibrate.IsVibrationOn = enable;
    }
    public void ToggleMusic(bool enable)
    {
        if (enable)
        {
            _audioMixerGroup.audioMixer.SetFloat("Music", 0);
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat("Music", -80);

        }
    }
    public void ToggleEffects(bool enable)
    {
        if (enable)
        {
            _audioMixerGroup.audioMixer.SetFloat("Effects", 0);
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat("Effects", -80);

        }
    }
    public void ActiveMenuWin()
    {
        StopGame();
        _menuWin.SetActive(true);
    }
    public void ActiveMenuLoseWithContinue()
    {
        StopGame();
        _menuLoseWithContinue.SetActive(true);
    }
    public void ActiveMenuLose()
    {
        StopGame();
        _menuLose.SetActive(true);
    }
    public void StopGame()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        Time.timeScale = 1.0f;
    }
    public void Restart()
    {
        StartGame();
       _state.Enter<LoadLevelState, int>(SceneManager.GetActiveScene().buildIndex);
        StartGame();
    }
    public void NextLevel()
    {
        StartGame();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        _state.Enter<LoadLevelState, int>(currentScene+1);
        StartGame();

    }
}
