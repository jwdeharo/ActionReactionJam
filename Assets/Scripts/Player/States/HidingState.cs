using UnityEngine;

public class HidingState : CState
{
    public override void UpdateState()
    {
        ((PlayerController)Controller).Animator.SetFloat("Speed", 1.0f);
        Controller.transform.position = Vector2.MoveTowards(Controller.transform.position, ((PlayerController)Controller).GetToHideTransform().position, 0.5f * Time.deltaTime);
        if (Vector2.Distance(Controller.transform.position, ((PlayerController)Controller).GetToHideTransform().position) == 0.0f)
        {
            
            ((PlayerController)Controller).Animator.SetFloat("Speed", -1.0f);
            ((PlayerController)Controller).ChangeSprite(false);
            Controller.GetFSM().PopState();
        }
    }
}
