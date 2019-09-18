using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectsMoveState : CState
{

    /**
     * Function that is called while the state is the current.
     */
    public override void UpdateState()
    {
        if (((MovableObjectsController)Controller).CanMove())
        {
            ((MovableObjectsController)Controller).transform.position += ((MovableObjectsController)Controller).GetMovement();
        }
        else
        {
            Controller.GetFSM().PopState();
        }
    }
}
