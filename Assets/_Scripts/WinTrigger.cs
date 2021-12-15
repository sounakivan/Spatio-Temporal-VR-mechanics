using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winScreen;
    public ChangeGameStates gameStateControl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winScreen.SetActive(true);
            gameStateControl.gameWin = true;
            gameStateControl.gameStarted = false;
        }
    }

}
