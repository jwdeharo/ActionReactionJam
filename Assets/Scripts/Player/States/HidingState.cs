using UnityEngine;

public class HidingState : CState
{
    public override void OnEnterState()
    {
        ((PlayerController)Controller).Animator.SetFloat("Speed", -1.0f);
        ((PlayerController)Controller).Animator.SetBool("TurningBox", true);
    }

    public override void UpdateState()
    {
        ((PlayerController)Controller).ChangeSprite(false);

        if (Utils.AnimationIsFinished(((PlayerController)Controller).Animator))
        {
            ((PlayerController)Controller).Animator.SetBool("AlreadyTurned", true);
            ((PlayerController)Controller).SetBox(true);
            Controller.GetFSM().PopState();
        }
    }
}
