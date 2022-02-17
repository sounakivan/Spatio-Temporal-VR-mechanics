using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeGameStates : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Text menuInfo;
    [SerializeField] private Text continueText;

    [SerializeField] ActionBasedController controller;
    //public GazeRaycast playerGaze;

    public AudioSource aud;
    public AudioClip selectClip;
    public AudioClip startClip;

    public bool gameStarted;
    public bool gameWin;

    private int index = 0;

    public string[] menuInfoTexts = new string[]
    {
        "It's time to catch a train...",
        "Being in a constant rush can make time seem to pass faster. Step inside a 'bubble' to re-orient your mental tick.",
        "Press the grip button to teleport to your gaze location indicated by a ring. The train arrives in 3 minutes. Ready?",
    };
    
    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        gameWin = false;
        
        index = 0;
        menuInfo.text = menuInfoTexts[index];

        controller.selectAction.action.performed += gripButtonPressed;
    }

    private void gripButtonPressed(InputAction.CallbackContext obj)
    {
        if (!gameStarted && index < menuInfoTexts.Length)
        {
            aud.PlayOneShot(selectClip);
            index += 1;
            menuInfo.text = menuInfoTexts[index];
        }
        else if (!gameStarted && index == menuInfoTexts.Length - 1)
        {
            aud.PlayOneShot(selectClip);
            continueText.text = "Press grip button twice to START";
        }
        else if (!gameStarted && index == menuInfoTexts.Length)
        {
            aud.PlayOneShot(startClip);
            gameStarted = true;
            menu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
