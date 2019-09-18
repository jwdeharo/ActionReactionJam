using UnityEngine;

public class WalkingState : IState
{
    private PlayerController Parent; //!< Controller of the parent.

    /**
     * Inits the state.
     * @param PlayerController: controller to be used in the state.
     */
    public void Init(PlayerController aParent)
    {
        Parent = aParent;
    }

    /**
     * Function that is called once the state is changed to be the current.
     */
    public void OnEnterState()
    {
        Parent.Animator.SetFloat("Speed", 1.0f);
    }

    /**
     * Function that is called while the state is the current.
     */
    public void UpdateState()
    {
        float HorizontalAxis = Input.GetAxis("Horizontal");
        if (HorizontalAxis == 0.0f)
        {
            Parent.GetFSM().ChangeState(Parent.GetState("Idle"));
        }
        else
        {
            Flip(HorizontalAxis);
            Vector3 Movement = new Vector3(HorizontalAxis, 0.0f, 0.0f);
            Parent.transform.position += Movement * Time.deltaTime * Parent.MoveSpeed;
        }
    }

    /**
     * Function that is called once the current state changes.
     */
    public void OnExitState()
    {
        Parent.Animator.SetFloat("Speed", -1.0f);
    }

    /**
     * Flips the direction of the player.
     * @param aHorizontalAxis: > 0 if right, < 0 if left.
     */
    void Flip(float aHorizontalAxis)
    {
        Vector3 ParentScale = Parent.transform.localScale;
        ParentScale.x = aHorizontalAxis > 0 ? 1.0f : -1.0f;

        if (ParentScale.x != Parent.transform.localScale.x)
        {
            Parent.transform.localScale = ParentScale;
        }
    }
}
