using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vibrate
{
    public static bool IsVibrationOn = true;
    public static void TriggerVibrate()
    {
        if (!IsVibrationOn)
            return;
        Handheld.Vibrate();
    }
}
