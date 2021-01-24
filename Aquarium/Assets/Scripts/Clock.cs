using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    private int hour_ = 0;
    private int minute_ = 0;
    private int seconds_ = 0;

    private Text textClock;
    float delta_time;
    private bool stop_clock_ = false;

    public static Clock instance;

    public void SetStopClock(bool stop)
    {
        stop_clock_ = stop;
    }

    private void Awake()
    {
        if (instance)
            Destroy(instance);

        instance = this;

        textClock = GetComponent<Text>();
        delta_time = 0;
    }

    void Start()
    {
        stop_clock_ = false;
    }

    void Update()
    {
        if (stop_clock_ == false)
        {
            delta_time += Time.deltaTime;
            TimeSpan span = TimeSpan.FromSeconds(delta_time);

            string hour = LeadingZero(span.Hours);
            string minute = LeadingZero(span.Minutes);
            string seconds = LeadingZero(span.Seconds);

            textClock.text = hour + ":" + minute + ":" + seconds;
        }
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

    public Text GetCurrentTime()
    {
        return textClock;
    }

}
