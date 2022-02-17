using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winScreen;
    public ChangeGameStates gameStateControl;
    public Animator trainAnimator;

    private void Start()
    {
        trainAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winScreen.SetActive(true);
            //gameStateControl.gameWin = true;
            //gameStateControl.gameStarted = false;
        }
    }

    private void Update()
    {
        if (gameStateControl != null)
        {
            if (gameStateControl.gameStarted)
            {
                trainAnimator.Play("TrainArrival", 0, 10f);
                //Debug.Log("train arriving...");
            }
        }
        
    }
}
