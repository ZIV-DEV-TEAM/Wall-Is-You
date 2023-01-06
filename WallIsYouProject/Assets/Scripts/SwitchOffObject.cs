using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SwitchOffObject : MonoBehaviour
{
    public void SwitchOff()
    {
        gameObject.SetActive(false);    
    }
}
