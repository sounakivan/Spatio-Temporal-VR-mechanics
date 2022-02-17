using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainArrivalControl : MonoBehaviour
{
    [SerializeField] private Text arrivalTime;
    public WatchUI timeKeeper;
    //public ChangeGameStates gameStates;

    //private bool trainArrived;

    // Start is called before the first frame update
    void Start()
    {
        //trainArrived = false;
        //trainArrivalAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float seconds = timeKeeper.timeUntilArrival;
        float minutes = seconds / 60;
        string minuteString = ((int)minutes).ToString("f0");
        string secondString = (seconds % 60).ToString("f0");

        arrivalTime.text = minuteString + ":" + secondString;

        if (timeKeeper.timeUntilArrival <= 0)
        {
            //trainArrived = true;
            arrivalTime.text = "00: 00";
        }
        else
        {
            arrivalTime.text = minuteString + ":" + secondString;
        }

    }

}
