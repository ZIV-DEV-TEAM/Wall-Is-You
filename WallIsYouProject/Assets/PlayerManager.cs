using System;
using System.Collections;
using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   private void Start()
   {
      StartCoroutine(LoginRoutine());
   }

   IEnumerator LoginRoutine()
   {
      bool done = false;
      LootLockerSDKManager.StartGuestSession((response) =>
         {
            if (response.success)
            {
               Debug.Log("player was Logged in");
               PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
               done = true;
            }
            else
            {
               Debug.Log("Could not start Session");
               done = true;
            }
         }
      );
      yield return new WaitWhile(() => done == false);
   }

}