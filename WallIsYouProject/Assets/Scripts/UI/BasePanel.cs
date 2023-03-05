using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public abstract class BasePanel : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button continueButton;
        private void Start()
        {
            restartButton.onClick.AddListener(OnRestart);
            if (continueButton != null)
                continueButton.onClick.AddListener(OnContinue);
        }
        private void OnRestart()
        {
            SceneManager.LoadScene("Play");
        }

        protected virtual void OnContinue()
        {
            Debug.Log("Continue");
        }
    }
}
