using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBubble : MonoBehaviour
{
    public WatchUI myWatch;
    [SerializeField] float timeSpeed = 0.5f;

    [SerializeField] Animator m_anim;

    private void Start()
    {
        m_anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myWatch.timeVariable = timeSpeed;

            m_anim.speed = timeSpeed;

            print(myWatch.timeVariable);
        }
    }

}
