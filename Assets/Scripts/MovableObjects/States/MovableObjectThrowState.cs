﻿
using UnityEngine;

public class MovableObjectThrowState : CState
{
    private MovableObjectsController TheMovableObjectsController;
    bool IsPlayingDestroy = false;
    public override void Init(BaseController aParent)
    {
        base.Init(aParent);
        TheMovableObjectsController = (MovableObjectsController)Controller;
    }

    public override void UpdateState()
    {
        TheMovableObjectsController.transform.Rotate(Vector3.forward * 100.0f * Time.deltaTime);
        TheMovableObjectsController.transform.position = Vector2.MoveTowards(TheMovableObjectsController.transform.position, TheMovableObjectsController.GetThrowingPosition(), TheMovableObjectsController.GetThrowSpeed() * Time.deltaTime);

        if (Vector2.Distance(TheMovableObjectsController.transform.position, TheMovableObjectsController.GetThrowingPosition()) == 0.0f)
        {
            TheMovableObjectsController.PlayDestroy();
            TheMovableObjectsController.SetThrowing(false);
            Controller.GetFSM().PopState();
            TheMovableObjectsController.TimeToKillAnim(true);
            TheMovableObjectsController.DestroyMovableObject();
        }
    }
}
