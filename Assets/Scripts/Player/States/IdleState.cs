﻿using UnityEngine;

public class IdleState : CState
{
    PlayerController MyPlayerController;

    public override void Init(BaseController aParent)
    {
        base.Init(aParent);
        MyPlayerController = (PlayerController)Controller;
    }

    /**
     * Function that is called while the state is the current.
     */
    public override void UpdateState()
    {
        if (((PlayerController)Controller).IsDead())
        {
            Controller.GetFSM().ChangeState(Controller.GetState("Death"));
        }
        else
        {
            if (((PlayerController)Controller).IsWaiting())
            {
                Controller.GetFSM().ChangeState(Controller.GetState("Wait"));
            }
            else if (((PlayerController)Controller).IsHiding() && !((PlayerController)Controller).IsChangedSprite())
            {
                Controller.GetFSM().ChangeState(Controller.GetState("Hide"));
            }
            else if (((PlayerController)Controller).IsBoxToPlayer())
            {
                Controller.GetFSM().ChangeState(Controller.GetState("BoxToPlayer"));
            }
            else if (MyPlayerController.IsClimbing())
            {
                Controller.GetFSM().ChangeState(Controller.GetState("Climb"));
            }
            else if (Input.GetAxisRaw("Horizontal") != 0.0f)
            {
                Controller.GetFSM().ChangeState(Controller.GetState("Walk"));
            }
        }
    }
}
