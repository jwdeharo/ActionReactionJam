using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FSM MyFSM;
    public Dictionary<string, IState> PlayerStates;
    public float MoveSpeed = 5.0f;
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        IdleState IdleState = new IdleState();
        WalkingState WalkState = new WalkingState();

        IdleState.Init(this);
        WalkState.Init(this);

        PlayerStates = new Dictionary<string, IState>();

        PlayerStates.Add("Idle", IdleState);
        PlayerStates.Add("Walk", WalkState);
        MyFSM = GetComponent<FSM>();
        MyFSM.StartFSM();
        MyFSM.ChangeState(IdleState, true);
    }

    public IState GetState(string aStateName)
    {
        return PlayerStates[aStateName];
    }
}
