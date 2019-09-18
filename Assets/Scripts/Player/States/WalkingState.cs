﻿using UnityEngine;

public class WalkingState : CState
{
    /**
     * Function that is called once the state is changed to be the current.
     */
    public override void OnEnterState()
    {
        Controller.Animator.SetFloat("Speed", 1.0f);
    }

    /**
     * Function that is called while the state is the current.
     */
    public override void UpdateState()
    {
        float HorizontalAxis = Input.GetAxis("Horizontal");
        if (HorizontalAxis == 0.0f)
        {
            Controller.GetFSM().ChangeState(Controller.GetState("Idle"));
        }
        else
        {
            Flip(HorizontalAxis);
            Vector3 Movement = new Vector3(HorizontalAxis, 0.0f, 0.0f);
            Controller.transform.position += Movement * Time.deltaTime * Controller.MoveSpeed;
        }
    }

    /**
     * Function that is called once the current state changes.
     */
    public override void OnExitState()
    {
        Controller.Animator.SetFloat("Speed", -1.0f);
    }

    /**
     * Flips the direction of the player.
     * @param aHorizontalAxis: > 0 if right, < 0 if left.
     */
    void Flip(float aHorizontalAxis)
    {
        Vector3 ParentScale = Controller.transform.localScale;
        ParentScale.x = aHorizontalAxis > 0 ? 1.0f : -1.0f;

        if (ParentScale.x != Controller.transform.localScale.x)
        {
            Controller.transform.localScale = ParentScale;
        }
    }
}