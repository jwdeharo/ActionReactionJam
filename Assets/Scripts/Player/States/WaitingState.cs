public class WaitingState : CState
{
    public override void UpdateState()
    {
        if (!((PlayerController)Controller).IsWaiting())
        {
            Controller.GetFSM().PopState();
        }
    }
}
