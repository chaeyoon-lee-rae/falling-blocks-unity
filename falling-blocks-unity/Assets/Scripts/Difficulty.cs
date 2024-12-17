using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Info outside of the scene -> no mono inherited
// Any class can access
public static class Difficulty
{
    const float secondsToMaxDiff = 60;
    public static float GetDiffPct()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDiff);
    }
}
