using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBubble : MonoBehaviour
{
    public WatchUI timeKeeper;
    //[SerializeField] float timeSpeed = 0.001f;

    //[SerializeField] GameObject animationControl;
    
    private void Start()
    {
        //m_anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timeKeeper._inTimeBubble = true;
                      
            //animationControl.GetComponent<Animator>().speed = timeSpeed;

            print("player entered bubble");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timeKeeper._inTimeBubble = false;
            //animationControl.GetComponent<Animator>().speed = timeSpeed;

            print("player exited bubble");
        }
    }
}
