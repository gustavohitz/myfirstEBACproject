using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour {

    public static HighScoreManager Instance; //Singleton
    private string _keyToSave = "KeyHighScore";
    
    [Header("References")]
    public TextMeshProUGUI uiTextHighScore;
    void Awake() {
        Instance = this;
    }
    void OnEnable() {
        UpdateText();
    }
    void UpdateText() {
        uiTextHighScore.text = PlayerPrefs.GetString(_keyToSave, "No high score");
    }

    public void SaveWinningPlayer(Player p) {
        if(p.playerName == "") return;
        PlayerPrefs.SetString(_keyToSave, p.playerName);
        UpdateText();
    }

}
