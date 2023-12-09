using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvasObject;
    // Start is called before the first frame update
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Game Manager is NULL");
            return _instance;
        }
    }
    void Start()
    {
        // Ensure the canvasObject is initially deactivated
        if (canvasObject != null)
        {
            canvasObject.SetActive(false);
        }
        else
        {
            Debug.LogError("CanvasObject is not assigned!");
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    public void AddScore()
    {
        // code here
    }

    public void GameOver()
    {
        // Check if the canvasObject is assigned
        if (canvasObject != null)
        {
            // Activate the canvasObject to show it
            canvasObject.SetActive(true);

            // Add any additional code or UI-related logic here
        }
        else
        {
            Debug.LogError("CanvasObject is not assigned!");
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene("FINAL_game");
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
