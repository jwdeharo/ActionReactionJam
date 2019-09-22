
public class WaitingState : CState
{
    public override void UpdateState()
    {
        if (((PlayerController)Controller).IsDead())
        {
            Controller.GetFSM().PopState();
            Controller.GetFSM().ChangeState(Controller.GetState("Death"));
        }
        else if (!((PlayerController)Controller).IsWaiting())
        {
            Controller.GetFSM().PopState();
        }
    }
}
