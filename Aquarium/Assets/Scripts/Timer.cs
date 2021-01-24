using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text time_text;

    void Start()
    {
        time_text.text = Clock.instance.GetCurrentTime().text;
    }
}
