using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerName, playerScore;

        public void SetInfo(string name, string score)
        {
            playerName.text = name;
            playerScore.text = score;
        }
    }
}