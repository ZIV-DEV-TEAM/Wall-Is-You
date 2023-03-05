using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    private int _leaderboarID = 11355;


    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID,scoreToUpload, _leaderboarID, (response) =>
            {
                if (response.success)
                {
                    Debug.Log("Successfully uploaded score");
                    done = true;
                }
                else
                {
                    Debug.Log("failed" + response.Error);
                    done = true;
                    
                }
            }
        );
        yield return new WaitWhile(()=>done == false);
    }
}
