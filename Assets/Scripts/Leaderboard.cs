using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Transform contextHolder;
    [SerializeField] private TMP_Text scorerText;
    [SerializeField] private TMP_Text nameText;
    
    private List<GameObject> spawnedTexts = new List<GameObject>();

    private bool _isSettingUpTheLeaderboard;
    
    void OnEnable()
    {
        RefreshScoreboard();
    }
    
    public void OpenRenamePanel()
    {
        PlayfabManager.Instance.OpenNamePanel();
    }

    public void RefreshScoreboard()
    {
        if (_isSettingUpTheLeaderboard) return;
        
        PlayfabManager.Instance.GetLeaderBoard(OnLeaderBoardGet);
        nameText.text = PlayfabManager.Instance.localPlayerName;
    }
    
    private void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        StartCoroutine(SetLeaderBoardRoutine(result));

    }
    
    private IEnumerator SetLeaderBoardRoutine(GetLeaderboardResult result)
    {
        _isSettingUpTheLeaderboard = true;
        
        foreach (var obj in spawnedTexts)
        {
            Destroy(obj);
        }

        spawnedTexts = new List<GameObject>();
    
        foreach (var r in result.Leaderboard)
        {
            TMP_Text text = Instantiate(scorerText, contextHolder);
            spawnedTexts.Add(text.gameObject);
            
            text.text = (r.Position + 1) + ". " 
                                         + r.StatValue 
                                         + " " + (r.DisplayName == null ? "UNKNOWN" : r.DisplayName)
                                         + (r.PlayFabId == PlayfabManager.Instance.localPlayerId ? " (You)" : "");
            
            
            // Wait for the next frame before continuing the loop
            yield return null;
        }

        _isSettingUpTheLeaderboard = false;
    }

}
