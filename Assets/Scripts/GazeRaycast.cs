using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeRaycast : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject cursor;
    public float cursorDistance = 7;
    public Image imgGaze;

    [SerializeField] float timerDuration = 2f;
    private bool gazeStatus;
    private bool _isRadialFilled;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        //imgGaze.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            onGazeEnter(hit);
        }
        else
        {
            onGazeExit();
        }

        if (gazeStatus)
        {
            ProgressRadialImage();
        }
    }

    void onGazeEnter(RaycastHit hit)
    {
        //imgGaze.enabled = true;
        gazeStatus = true;
        cursor.gameObject.GetComponent<Renderer>().material.color = Color.green;
        cursor.transform.position = hit.point;

        if (imgGaze.fillAmount == 1 && hit.transform.CompareTag("Teleporter"))
        {
            hit.transform.gameObject.GetComponent<Teleport>().teleportPlayer();
            Debug.Log("teleporting");
        }
    }

    void onGazeExit()
    {
        //imgGaze.enabled = false;
        _isRadialFilled = false;
        gazeStatus = false;
        ResetProgress();

        cursor.transform.position.Set(cursorDistance, cursorDistance, cursorDistance);
        cursor.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public void StartProgress()
    {
        _isRadialFilled = false;
    }

    public bool ProgressRadialImage()
    {
        if (_isRadialFilled == false)
        {
            //advance timer
            _timer += Time.deltaTime;
            imgGaze.fillAmount = _timer / timerDuration;

            //if timer exceeds duration, complete progress and reset
            if (_timer >= timerDuration+1)
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
        imgGaze.fillAmount = 0f;
    }
}
