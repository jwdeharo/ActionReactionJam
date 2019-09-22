
public class BoxToPlayerState : CState
{

    public override void OnEnterState()
    {
        ((PlayerController)Controller).Animator.SetBool("TurningPlayer", false);
    }

    public override void UpdateState()
    {
        if (Utils.AnimationIsFinished(((PlayerController)Controller).Animator))
        {
            Controller.GetFSM().PopState();
        }
    }

    public override void OnExitState()
    {
        ((PlayerController)Controller).Animator.SetBool("TurningPlayer", true);
        ((PlayerController)Controller).SetBoxToPlayer(false);
    }
}
