using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchUI : MonoBehaviour
{
    public ChangeGameStates gameStateControl;
    
    [SerializeField] private Transform secondHandTransform;
    [SerializeField] private Transform minuteHandTransform;
    [SerializeField] private Text timeText;

    private float counter = 0;
    public float timeVariable = 1f;
    public float trainArrivalTime = 180f;
    public float timeUntilArrival;

    public bool _inTimeBubble = false;

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        //if game has not started
        if (!gameStateControl.gameStarted)
        {
            timeText.text = "00:00";
        }
        
        //if game has started
        if (gameStateControl.gameStarted)
        {
            counter += Time.deltaTime;
            float rateOfSeconds = counter * timeVariable;
            Debug.Log(rateOfSeconds);
            float secondsDegree = -(rateOfSeconds / 60f) * 360f;

            secondHandTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, secondsDegree));
            minuteHandTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, (secondsDegree) / 60f));

            float minutes = rateOfSeconds / 60;
            string minuteString = ((int)minutes).ToString("f0");
            string secondString = (rateOfSeconds % 60).ToString("f0");

            timeText.text = minuteString + ":" + secondString;

            //time speeds up and slows down accordingly
            if (!_inTimeBubble && timeVariable < 2.6)
            {
                timeVariable += 0.001f / 3;
            }
            else if (_inTimeBubble && timeVariable > 1)
            {
                timeVariable -= 0.001f;
            }

            //train approach timer
            timeUntilArrival = trainArrivalTime - rateOfSeconds;
        }

    }
}
