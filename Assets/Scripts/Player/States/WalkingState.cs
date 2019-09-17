using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : IState
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
        Debug.Log("Entering Walking state");
    }

    /**
     * Function that is called while the state is the current.
     */
    public void UpdateState()
    {
        Debug.Log("Updating Walking state");

        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            Debug.Log("ChangingState");
        }
    }

    /**
     * Function that is called once the current state changes.
     */
    public void OnExitState()
    {
        Debug.Log("Exiting Walking state");
    }
}
