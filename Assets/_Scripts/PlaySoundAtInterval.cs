using UnityEngine;
using System.Collections;

// PlaySoundAtInterval.cs
// Copyright (c) 2010-2011 Sigma-Tau Productions (http://www.sigmatauproductions.com/).
// This script is free to be used in both free and commercial projects as long as this
// notice is retained.

[RequireComponent(typeof(AudioSource))]
public class PlaySoundAtInterval : MonoBehaviour
{
    public AudioSource audioSource;
    public WatchUI timekeeper;
    
    // Public variables
    // Will the sound play on startup?
    public bool playAtStartup = false;

    // The interval of time (in seconds) that the sound will be played.
    public float interval = 3.0f;

    // The sound itself.
    public AudioClip clipToPlay;

    // Private variables
    // A modifier that will prevent the script from running in the event of an error
    private bool disableScript = false;

    // The amount of time that has passed since the last initial playback of the sound.
    private float trackedTime = 0.0f;

    // Tracks to see if we've played this at startup.
    private bool playedAtStartup = false;

    // Use this for initialization
    void Start()
    {
        if (interval < 1.0f)
        { // Make sure the interval isn't 0, or we'll be constantly playing the sound!
            Debug.LogError("Interval base must be at least 1.0!");
            disableScript = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!disableScript)
        {
            // Play the sound when the scene starts
            if (playAtStartup == !playedAtStartup) {
                audioSource.PlayOneShot(clipToPlay);
                playedAtStartup = true;
            }

            // Increment the timer
            trackedTime += Time.deltaTime;

            // Check to see that the proper amount of time has passed
            float intervalRate = interval - (timekeeper.timeVariable); //added by Sounak
            //Debug.Log(intervalRate);
            if (trackedTime >= intervalRate)
            {
                // Play the sound, reset the timer
                audioSource.PlayOneShot(clipToPlay);
                trackedTime = 0.0f;
            }
        }
    }


}
