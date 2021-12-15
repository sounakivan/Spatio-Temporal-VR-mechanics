using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GazeRaycast : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera playerCamera;
    [SerializeField] ActionBasedController actionBasedController;
    [SerializeField] GameObject teleportReticle;
    private GameObject teleportReticleInstance;
    private Transform teleportHere;

    public ChangeGameStates gameControl;

    [SerializeField] Image reticleImage;
    [SerializeField] Image gazeTimerImage;

    [SerializeField] float timerDuration = 2.5f;
    public WatchUI myWatch;

    public bool _teleportActive;
    private bool _isRadialFilled;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        teleportReticleInstance = Instantiate(teleportReticle);
        ResetProgress();

        actionBasedController.selectAction.action.performed += teleportActivated;
    }

    private void teleportActivated(InputAction.CallbackContext obj)
    {
        if (gameControl.gameStarted)
        {
            _teleportActive = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            if (hit.transform.CompareTag("Teleportable"))
            {
                UpdateTeleportReticle(hit);
                Teleport(hit);
            }
            //else if (hit.transform.CompareTag("Watch") && !myWatch._inTimeBubble)
            //{
                //Debug.Log("looking at watch");
                //myWatch.timeVariable += 0.001f;
            //}
            else
            {
                onGazeExit();
            }
        }

        if (_teleportActive)
        {
            LoadGazeTimer();
        }

        //Debug.Log(myWatch.timeVariable);
    }

    void UpdateTeleportReticle(RaycastHit hit)
    {
        //teleportReticleInstance.SetActive(true);
        teleportReticleInstance.transform.position = hit.point;
        teleportReticleInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

        //hover on teleportable area
        reticleImage.color = Color.red;
        
    }

    void Teleport(RaycastHit hit)
    {
        if (gazeTimerImage.fillAmount == 1 && hit.transform.CompareTag("Teleportable"))
        {
            player.transform.position = hit.point;
            //Debug.Log("teleporting");
        }
    }

    void onGazeExit()
    {
        _isRadialFilled = false;
        _teleportActive = false;
        ResetProgress();
        reticleImage.color = Color.white;
    }

    public void StartProgress()
    {
        _isRadialFilled = false;
    }

    public bool LoadGazeTimer()
    {
        if (_isRadialFilled == false)
        {
            //advance timer
            _timer += Time.deltaTime;
            gazeTimerImage.fillAmount = _timer / timerDuration;

            //if timer exceeds duration, complete progress and reset
            if (_timer >= timerDuration + 0.05f)
            {
                ResetProgress();
                _isRadialFilled = true;
                return true;
            }
        }
        return false;
    }

    public void ResetProgress()
    {
        _timer = 0f;
        gazeTimerImage.fillAmount = 0f;
    }
}
