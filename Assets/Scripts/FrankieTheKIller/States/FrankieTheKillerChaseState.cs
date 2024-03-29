﻿using UnityEngine;

public class FrankieTheKillerChaseState : CState
{
    private ViewFinderController    MyFrankieController;
    private PlayerController        GamePlayerController;

    public override void Init(BaseController aParent)
    {
        base.Init(aParent);
        MyFrankieController = (ViewFinderController)Controller;
        GamePlayerController = MyFrankieController.GetTarget().GetComponentInParent<PlayerController>();
    }

    public override void UpdateState()
    {
        if (GamePlayerController != null && (GamePlayerController.IsHiding() || GamePlayerController.IsDead()))
        {
            Controller.GetFSM().PopState();
            if (GamePlayerController.IsDead())
            {
                MyFrankieController.PlayShot();
            }
        }
        else
        {
            Controller.transform.position = Vector2.MoveTowards(Controller.transform.position, MyFrankieController.GetTarget().transform.position, MyFrankieController.GetChasingSpeed() * Time.deltaTime);
        }
    }
}
