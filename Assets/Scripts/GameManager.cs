using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //PUBLIC FIELDS
    
    public GameObject canvasObject;
    public TMP_Text bestScoreText;
    public TMP_Text inGameScoreText;
    
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

    public float score;
    public bool isGameOver;
    public float scoreMultiplier = 3.0f;
    
    //MONOBEHAVIOURS
    
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

        SavesManager.Load();
    }
    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        AddScore();
    }
    
    //PRIVATE METHODS
    
    private void AddScore()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime * 3; // Adjust the multiplier to change the counting speed
            inGameScoreText.text = Mathf.FloorToInt(score).ToString();
        }
    }

    private void SetBestScore(int value)
    {
        if (value > SavesManager.SavePlayerData.bestScore)
        {
            SavesManager.SetBestScore(value);
            bestScoreText.text = $"NEW BEST\n{value}";
        }
        else
            bestScoreText.text = $"score: {value}\n Best: {SavesManager.SavePlayerData.bestScore}";
    }
    
    // PUBLIC METHODS
    
    public void GameOver()
    {
        isGameOver = true;
        
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
        
        //Save the best score to Savemanager
        //compare if the last saved best score is smaller than the score that it has now
        SetBestScore((int)score);
    }


    public void Restart()
    {
        SceneManager.LoadScene("FINAL_game", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
    
}
