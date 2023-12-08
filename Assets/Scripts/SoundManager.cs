using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    // BG music playing
    // randomly play Junseis sfx at certain interval

    // public AudioClip backgroundTrack; // change to bgm track
    public AudioClip[] backgroundTracks;
    private AudioSource _audiosource;
    void Start()
    {
        // Play + Loop BGM
        _audiosource = gameObject.AddComponent<AudioSource>();
        
        // Schedule the PlayRandomTrack method to be called every 10 seconds
        InvokeRepeating("PlayRandomTrack", 0f, 20f); 
        
        // audiosource.clip = backgroundTrack;

        _audiosource.loop = true;
        
        _audiosource.Play();
        Debug.Log("BGM is playing");
    }
    
    void PlayRandomTrack()
    {
        // Check if there are audio clips in the array
        if (backgroundTracks.Length > 0)
        {
            // Choose a random index
            int randomIndex = Random.Range(0, backgroundTracks.Length);

            // Set the chosen audio clip to the AudioSource
            _audiosource.clip = backgroundTracks[randomIndex];

            // Play the background track
            _audiosource.Play();

            // Debug statement
            Debug.Log("Playing random background track: " + _audiosource.clip.name);
        }
        else
        {
            // Debug statement if the array is empty
            Debug.LogWarning("No background tracks found.");
        }
    }
    
}