using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    public static SettingsManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadLobby()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
