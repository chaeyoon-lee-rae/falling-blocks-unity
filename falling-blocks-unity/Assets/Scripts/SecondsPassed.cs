using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondsPassed : MonoBehaviour
{
    public TextMeshProUGUI secondsPassed;

    // Update is called once per frame
    void Update()
    {
        secondsPassed.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    }
}
