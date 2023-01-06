using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class UIMenu : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
