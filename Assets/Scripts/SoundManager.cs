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

    public Sound[] soundList;
    private AudioSource _audiosource;
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Sound Manager is NULL");
            return _instance;
        }
    }
    void Start()
    {
        // Play + Loop BGM
        _audiosource = gameObject.AddComponent<AudioSource>();
        
        // Schedule the PlayRandomTrack method to be called every 10 seconds
        InvokeRepeating("PlayRandomTrack", 0f, 20f); 
        
        // audiosource.clip = backgroundTrack;

        BackgroundSoundtrack();
    }
    
    void PlayRandomTrack()
    {
        // Check if there are audio clips in the array
        if (backgroundTracks.Length > 0)
        {
            // Choose a random index
            int randomIndex = Random.Range(0, backgroundTracks.Length);
            
            // Play the background track
            _audiosource.PlayOneShot(backgroundTracks[randomIndex]);

            // Debug statement
            Debug.Log("Playing random background track: " + _audiosource.clip.name);
        }
        else
        {
            // Debug statement if the array is empty
            Debug.LogWarning("No background tracks found.");
        }
    }

    void BackgroundSoundtrack()
    {
        foreach (var soundObj in soundList)
        {
            if (soundObj.clipName == "Background_Music") // Clip MUST be names Background_Music
            {
                print("hello world");
                //Play that audioclip
                _audiosource.clip = soundObj.audioClip;
                _audiosource.Play();
            }
        }
    }
    
    public void GeneralPlaySoundEffect(string name) //get parameter of name for the Clipname
    {
        foreach (var soundObj in soundList)
        {
            if (soundObj.clipName == name)
            {
                print("Jump");
                _audiosource.PlayOneShot(soundObj.audioClip);
            }
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    
}

[System.Serializable]
public struct Sound
{
    public AudioClip audioClip;
    public string clipName;
}
