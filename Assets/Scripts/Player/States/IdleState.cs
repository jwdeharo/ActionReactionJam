using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController Parent;
    public void Init(PlayerController aParent)
    {
        Parent = aParent;
    }

    /**
     * Function that is called once the state is changed to be the current.
     */
    public void OnEnterState()
    {
        Debug.Log("Idle");
    }

    /**
     * Function that is called while the state is the current.
     */
    public void UpdateState()
    {
        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            Parent.MyFSM.ChangeState(Parent.GetState("Walk"), true);
        }
    }

    /**
     * Function that is called once the current state changes.
     */
    public void OnExitState()
    {
    }
}
