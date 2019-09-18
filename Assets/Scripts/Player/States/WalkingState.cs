using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : IState
{
    private PlayerController Parent;
    

    public void Init(PlayerController aParent)
    {
        Parent = aParent;
    }

    /**
     * Function that is called once the state is changed to be the current.
     */
    public void OnEnterState()
    {
        Debug.Log("Entering Walking state");
    }

    /**
     * Function that is called while the state is the current.
     */
    public void UpdateState()
    {
        float HorizontalAxis = Input.GetAxis("Horizontal");
        Parent.Animator.SetFloat("Speed", Mathf.Abs(HorizontalAxis));
        if (HorizontalAxis == 0.0f)
        {
            Parent.MyFSM.ChangeState(Parent.GetState("Idle"));
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
    }

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
