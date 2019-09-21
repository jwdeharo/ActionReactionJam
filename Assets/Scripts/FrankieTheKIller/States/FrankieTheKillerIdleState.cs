using UnityEngine;

public class FrankieTheKillerIdleState : CState
{
    private ViewFinderController    MyFrankieController;
    private PlayerController GamePlayerController;
    private float Timer;
    private float MaxTime = 1.5f;

    public override void Init(BaseController aParent)
    {
        base.Init(aParent);
        MyFrankieController = (ViewFinderController)Controller;
        GamePlayerController = MyFrankieController.GetTarget().GetComponentInParent<PlayerController>();
    }

    public override void OnEnterState()
    {
        Timer = 0.0f;
    }

    /**
     * Function that is called while the state is the current.
     */
    public override void UpdateState()
    {
        Timer += Time.deltaTime;

        if (GamePlayerController != null && (!GamePlayerController.IsHiding() && !GamePlayerController.IsDead() && Timer >= MaxTime))
        {
            GamePlayerController.ToWait(false);
            Controller.GetFSM().ChangeState(Controller.GetState("Chase"));
        }
        else
        {
            MyFrankieController.CircleMovement();
        }
    }
}
