
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChangePanel
    {
        private CanvasGroup _currentPanel;

        public void SetPanel(CanvasGroup newPanel)
        {
            if (_currentPanel != null)
            {
                _currentPanel.interactable = false;
                _currentPanel.alpha = 0;
                _currentPanel.blocksRaycasts = false;
            }
            _currentPanel = newPanel;
            _currentPanel.interactable = true;
            _currentPanel.alpha = 1;
            _currentPanel.blocksRaycasts = true;
        }
    }
}