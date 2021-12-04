using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeRaycast : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] Image reticleImage;
    [SerializeField] Image gazeTimerImage;

    [SerializeField] float timerDuration = 3f;
    private bool gazeStatus;
    private bool _isRadialFilled;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        //reticleImage.color = Color.clear;
        ResetProgress();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            if (hit.transform.CompareTag("Teleporter"))
            {
                gazeStatus = true;
                reticleImage.color = Color.green;
            }
            else
            {
                onGazeExit();
            }
            Teleport(hit);
        }

        if (gazeStatus)
        {
            LoadGazeTimer();
        }
    }

    void Teleport(RaycastHit hit)
    {
        if (gazeTimerImage.fillAmount == 1 && hit.transform.CompareTag("Teleporter"))
        {
            hit.transform.gameObject.GetComponent<Teleport>().teleportPlayer();
            //Debug.Log("teleporting");
        }
    }

    void onGazeExit()
    {
        _isRadialFilled = false;
        gazeStatus = false;
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
            if (_timer >= timerDuration + 0.4f)
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
