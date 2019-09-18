﻿using UnityEngine;

public class MovableObjectIdleState : CState
{
    /**
     * Function that is called while the state is the current.
     */
    public override void UpdateState()
    {
        if (((MovableObjectsController)Controller).CanMove())
        {
            Controller.GetFSM().ChangeState(Controller.GetState("Move"));
        }
    }
}
