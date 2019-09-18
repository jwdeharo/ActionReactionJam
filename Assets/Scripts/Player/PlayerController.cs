using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private FSM MyFSM;                              //!< Finite state machine of the player.
    public Dictionary<string, IState> PlayerStates; //!< List of states that the player have.
    public float MoveSpeed = 5.0f;                  //!< Velocity of the player.
    public Animator Animator;                       //!< Animator which handles the animations.

    /**
     * Start is called before the first frame update
     */
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

    /**
     * Returns a state from the dictionary of states.
     * @param aStateName: State to return.
     */
    public IState GetState(string aStateName)
    {
        return PlayerStates[aStateName];
    }

    /**
     * Returns the FSM of the player.
     * @return FSM: FSM of the player.
     */
    public FSM GetFSM()
    {
        return MyFSM;
    }
}
