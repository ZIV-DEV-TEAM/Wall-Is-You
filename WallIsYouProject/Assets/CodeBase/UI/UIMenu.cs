using CodeBase.Infrastructure;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private CanvasGroup _menuLoseWithContinue;
        [SerializeField] private CanvasGroup _menuWin;
        [SerializeField] private CanvasGroup _menuLose;
        [SerializeField] private CanvasGroup leaderBoardPanel;
        [SerializeField] private CanvasGroup menu;
        [SerializeField] private CanvasGroup playPanel;

        private ChangePanel _changePanel;
        
        private GameStateMachine _state;

        [Inject]
        public void Construct(GameStateMachine state)
        {
            PlayPanel();
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

        public void PlayPanel()
        {
            _changePanel.SetPanel(playPanel);
        }

        public void Menu()
        {
            _changePanel.SetPanel(menu);
        }

        public void ActiveMenuWin()
        {
            StopGame();
            _changePanel.SetPanel(_menuWin);
        }

        public void ActiveMenuLoseWithContinue()
        {
            StopGame();
            _changePanel.SetPanel(_menuLoseWithContinue);
        }

        public void ActiveMenuLose()
        {
            _changePanel.SetPanel(_menuLose);
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
            _state.Enter<LoadLevelState, int>(currentScene + 1);
            StartGame();

        }

        public void Leaderboard()
        {
            _changePanel.SetPanel(leaderBoardPanel);
        }
    }
}