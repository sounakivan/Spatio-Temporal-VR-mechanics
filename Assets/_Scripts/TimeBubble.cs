using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBubble : MonoBehaviour
{
    public WatchUI myWatch;
    [SerializeField] float timeSpeed = 0.5f;

    [SerializeField] GameObject animationControl;
    
    private void Start()
    {
        //m_anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myWatch.timeVariable = timeSpeed;

            animationControl.GetComponent<Animator>().speed = timeSpeed;

            //print(myWatch.timeVariable);
        }
    }

}
