using UnityEngine;

public class IdleState : CState
{
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
            if (Input.GetAxisRaw("Horizontal") != 0.0f)
            {
                Controller.GetFSM().ChangeState(Controller.GetState("Walk"));
            }
        }
    }
}
