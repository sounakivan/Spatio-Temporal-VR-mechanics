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
    public GazeRaycast playerGaze;

    public AudioSource aud;
    public AudioClip selectClip;
    public AudioClip startClip;

    public bool gameStarted;
    public bool gameWin;

    private int index = 0;

    public string[] menuInfoTexts = new string[]
    {
        "The train is approaching soon... can you make it on time?",
        "Being in a hurry can be stressful. Time seems to keep ticking faster and faster!",
        "Step inside the 'bubble' zones to re-orient your mental tick to normal speed, before returning to the rush hour scramble.",
        "Use the gaze pointer to locate your next position, then press the grip button to teleport to it.",
        "Ready to catch a train? Ok then, godspeed!"
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
        
        if (!gameStarted && index == menuInfoTexts.Length - 1)
        {
            aud.PlayOneShot(selectClip);
            continueText.text = "Press grip button to START";
        }

        if (!gameStarted && index == menuInfoTexts.Length)
        {
            aud.PlayOneShot(startClip);
            gameStarted = true;
            menu.SetActive(false);
        }

        if (gameStarted)
        {
            playerGaze._teleportActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
