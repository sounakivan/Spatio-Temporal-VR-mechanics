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

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        float t = Time.time - startTime;
        int minutes = (int) t / 60;
        float seconds = (t * timeVariable) % 60;

        float secondsDegree = -(seconds / 60f) * 360f;

        secondHandTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, secondsDegree));
        minuteHandTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, (secondsDegree) / 60f));

        string minuteString = minutes.ToString();
        string secondString = seconds.ToString("f0");

        timeText.text = minuteString + ":" + secondString;
    }
}
