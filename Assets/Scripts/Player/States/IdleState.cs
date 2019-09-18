
using UnityEngine;

public class IdleState : CState
{
    /**
     * Function that is called while the state is the current.
     */
    public override void UpdateState()
    {
        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            Controller.GetFSM().ChangeState(Controller.GetState("Walk"), true);
        }
    }
}
