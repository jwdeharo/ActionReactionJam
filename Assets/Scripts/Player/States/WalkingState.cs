using UnityEngine;

public class WalkingState : CState
{
    /**
     * Function that is called once the state is changed to be the current.
     */
    public override void OnEnterState()
    {
        string SpeedString = ((PlayerController)Controller).IsHiding() ? "SpeedBox" : "Speed";
        ((PlayerController)Controller).Animator.SetFloat(SpeedString, 1.0f);
    }

    /**
     * Function that is called while the state is the current.
     */
    public override void UpdateState()
    {
        if (((PlayerController)Controller).IsDead())
        {
            Controller.GetFSM().ChangeState(Controller.GetState("Death"));
        }
        else if (((PlayerController)Controller).IsWaiting())
        {
            Controller.GetFSM().PopState();
            Controller.GetFSM().ChangeState(Controller.GetState("Wait"));
        }
        else if (((PlayerController)Controller).IsHiding() && !((PlayerController)Controller).IsChangedSprite())
        {
            Debug.Log("Update state");
            Controller.GetFSM().ChangeState(Controller.GetState("Hide"));
        }
        else
        {
            float HorizontalAxis = Input.GetAxisRaw("Horizontal");

            if (HorizontalAxis == 0.0f)
            {
                Controller.GetFSM().PopState();
            }
            else
            {
                ((PlayerController)Controller).transform.position += ((PlayerController)Controller).GetMovement();
                Flip(HorizontalAxis);
            }
        }
    }

    /**
     * Function that is called once the current state changes.
     */
    public override void OnExitState()
    {
        Debug.Log("Exit state");
        string SpeedString = ((PlayerController)Controller).IsHiding() ? "SpeedBox" : "Speed";
        ((PlayerController)Controller).Animator.SetFloat(SpeedString, -1.0f);
    }

    /**
     * Flips the direction of the player.
     * @param aHorizontalAxis: > 0 if right, < 0 if left.
     */
    void Flip(float aHorizontalAxis)
    {

        Vector3 ParentScale = Controller.transform.localScale;

        if (aHorizontalAxis > 0.0f)
        {
            ParentScale.x = Mathf.Abs(ParentScale.x);
        }
        else
        {
            if (ParentScale.x > 0.0f)
            {
                ParentScale.x *= -1.0f;
            }
        }

        if (ParentScale.x != Controller.transform.localScale.x)
        {
            Controller.transform.localScale = ParentScale;
        }
    }
}
