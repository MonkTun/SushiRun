using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 240;
    }
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
