using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    public enum States {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> dictionaryState;

    private StateBase _currentState;
    public float timeToStartGame = 1f;
    public static StateMachine Instance;
    public BallBase ballBase;

    private void Awake() {
        Instance = this;

        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, new StateBase());
        dictionaryState.Add(States.PLAYING, new StatePlaying());
        dictionaryState.Add(States.RESET_POSITION, new StateResetPosition());
        dictionaryState.Add(States.END_GAME, new StateEndGame());

        SwitchState(States.MENU);
    }

    public void SwitchState(States state) {
        if(_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];
        _currentState.OnStateEnter(ballBase);
    }
    private void Update() {
        if(_currentState != null) _currentState.OnStateStay();

        if(Input.GetKeyDown(KeyCode.Return)) {
            SwitchState(States.PLAYING);
        }
    }
    public void ResetPosition() {
        SwitchState(States.RESET_POSITION);
    }
   
}
