using UnityEngine;

public class HidingState : CState
{
    public override void UpdateState()
    {
        ((PlayerController)Controller).Animator.SetFloat("Speed", -1.0f);
        ((PlayerController)Controller).ChangeSprite(false);
        Controller.GetFSM().PopState();
    }
}
