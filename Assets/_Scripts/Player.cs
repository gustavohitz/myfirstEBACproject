using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed = 10;
    public int maxPoints = 2;
    public Rigidbody2D myRigidbody2D;
    public Image uiPlayer;
    public string playerName;
    
    [Header("Key Setup")]
    public KeyCode KeyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode KeyCodeMoveDown = KeyCode.DownArrow;
    
    [Header("Score")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;
    
    
    void Awake() {
        ResetPlayer();
    }

    void Update() {
        if(Input.GetKey(KeyCodeMoveUp)) {
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
        }
        else if(Input.GetKey(KeyCodeMoveDown)) {
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed);
        }
    }
    public void ChangeColor(Color c) {
        uiPlayer.color = c;
    }
    public void AddPoint() {
        currentPoints++;
        UIUpdate();
        CheckMaxPoints();
    }
    public void ResetPlayer() {
        currentPoints = 0;
        UIUpdate();
    }
    private void UIUpdate() {
        uiTextPoints.text = currentPoints.ToString();
    }
    private void CheckMaxPoints() {
        if(currentPoints >= maxPoints) {
            GameManager.Instance.EndGame();
            HighScoreManager.Instance.SaveWinningPlayer(this);
        }
    }
    public void SetName(string s) {
        playerName = s;
    }
}
