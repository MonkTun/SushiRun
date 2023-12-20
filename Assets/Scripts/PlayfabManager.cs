using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    // PUBLIC FIELDS
    public static PlayfabManager Instance { get; private set; }
    public string localPlayerId { get; private set; }
    public string localPlayerName { get; private set; }

    // PRIVATE FIELDS
    [SerializeField] private Transform _loginCanvas;
    [SerializeField] private TMP_InputField _loginField;
    [SerializeField] private TMP_Text _deniedInfoText;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        Login();
    }

    // Scoreboard METHODS

    public void SendLeaderBoard(int score)
    {
        if (!PlayFabClientAPI.IsClientLoggedIn()) return;
        
        var request = new UpdatePlayerStatisticsRequest()
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate()
                {
                    StatisticName = "BestScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    private void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("ScoreBoard Sent Success");
    }

    public void GetLeaderBoard(Action<GetLeaderboardResult> callback)
    {
        if (!PlayFabClientAPI.IsClientLoggedIn())
        {
            Login();
            return;
        }
        
        var request = new GetLeaderboardRequest()
        {
            StatisticName = "BestScore",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        
        PlayFabClientAPI.GetLeaderboard(request, callback, OnError);
    }

    public void GetPlacement(Action<GetLeaderboardAroundPlayerResult> callback)
    {
        if (!PlayFabClientAPI.IsClientLoggedIn())
        {
            Login();
            return;
        }
        
        var request = new GetLeaderboardAroundPlayerRequest()
        {
            StatisticName = "BestScore",
            MaxResultsCount = 2
        };
        
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, callback, OnError);
    }
    
    // Login METHODS
    
    private void Login()
    {
        var request = new LoginWithCustomIDRequest()
        {
            CustomId = SavesManager.DeviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams()
            {
                GetPlayerProfile = true
            }
        };
        
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    private void OnSuccess(LoginResult loginResult)
    {
        Debug.Log("Login Success");

        localPlayerId = loginResult.PlayFabId;

        string name = null;
        
        if (loginResult.InfoResultPayload.PlayerProfile != null)
            name = loginResult.InfoResultPayload.PlayerProfile.DisplayName;

        if (name != null)
        {
            localPlayerName = name;
        }
        else
        {
            OpenNamePanel();
        }
    }

    public void OpenNamePanel()
    {
        _loginCanvas.gameObject.SetActive(true);
    }
    
    public void UpdateName()
    {
        if (_loginField.text.Length < 3)
        {
            _loginField.text = "has to be longer than 3 characters!";
            return;
        }
        
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = _loginField.text,
        };
        
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnUserNameUpdated, OnError);
    }

    private void OnUserNameUpdated(UpdateUserTitleDisplayNameResult result)
    {
        localPlayerName = result.DisplayName;
        _loginCanvas.gameObject.SetActive(false);

        Leaderboard lead = FindObjectOfType<Leaderboard>();
        if (lead)
        {
            lead.RefreshScoreboard();
        }
    }
    
    private void OnError(PlayFabError error)
    {
        Debug.Log($"ERROR: {error.ErrorMessage}");
    }
}
