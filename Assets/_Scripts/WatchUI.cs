using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchUI : MonoBehaviour
{
    [SerializeField] private Transform secondHandTransform;
    [SerializeField] private Transform minuteHandTransform;
    [SerializeField] private Text timeText;

    public float timeVariable = 1f;
    private float startTime;
    public float trainArrivalTime = 180f;
    public float timeUntilArrival;

    public bool _inTimeBubble = false;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        float t = Time.time - startTime;
        float seconds = t % 60;
        float rateOfSeconds = seconds * timeVariable;
        float secondsDegree = -(rateOfSeconds / 60f) * 360f;

        secondHandTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, secondsDegree));
        minuteHandTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, (secondsDegree) / 60f));

        float minutes = rateOfSeconds / 60;
        string minuteString = ((int) minutes).ToString("f0");
        string secondString = (rateOfSeconds % 60).ToString("f0");

        timeText.text = minuteString + ":" + secondString;

        //time speeds up and slows down accordingly
        if (!_inTimeBubble)
        {
            timeVariable += 0.001f;
        }
        else if (_inTimeBubble && timeVariable > 1)
        {
            timeVariable -= 0.001f;
        }
        else
        {
            timeVariable = 1f;
        }

        //Debug.Log(rateOfSeconds);

        timeUntilArrival = trainArrivalTime - rateOfSeconds;
    }
}
