using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour {

    public Vector3 speed = new Vector3(1, 1, 0);
    public string keyToCheck = "Player";
    private Vector3 _startSpeed;
    private bool _canMove = false;
    
    [Header("Randomization")]
    public Vector2 randSpeedY = new Vector2(1, 3);
    public Vector2 randSpeedX = new Vector2(1, 3);

    private Vector3 _startPosition;

    void Awake() {
        _startPosition = transform.position;
        _startSpeed = speed;
    }

    void Update() {
        if(!_canMove) return;
        transform.Translate(speed);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == keyToCheck) {
            OnPlayerCollision();
        }
        else {
            speed.y *= -1;
        } 
    }
    void OnPlayerCollision() {
        speed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if(speed.x < 0) {
            rand = -rand;
        }

        speed.x = rand;

        //rand = Random.Range(randSpeedY.x, randSpeedY.y);
        //speed.y = rand;
    }

    public void ResetBall() {
        transform.position = _startPosition;
        speed = _startSpeed;
    }
    public void CanMove(bool state) {
        _canMove = state;
    }
}
