using System.Collections.Generic;
using UnityEngine;

public class MovableObjectsController : BaseController
{
    private Vector3 Movement; //!< Movement of the movable object.

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        MovableObjectIdleState IdleState = new MovableObjectIdleState();
        MovableObjectsMoveState MoveState = new MovableObjectsMoveState();

        IdleState.Init(this);
        MoveState.Init(this);

        States = new Dictionary<string, CState>();
        States.Add("Idle", IdleState);
        States.Add("Move", MoveState);

        Movement = new Vector3();

        MyFSM = GetComponent<FSM>();
        MyFSM.StartFSM();
        MyFSM.ChangeState(IdleState);
    }

    /**
     * Applies a movement.
     * @param aMovement: new movement to apply.
     */
    public void ApplyMovement(Vector3 aMovement)
    {
        Movement = aMovement;
    }

    /**
     * Checks if the movable object can move.
     * @return True if it can move, false if it can't.
     */
    public bool CanMove()
    {
        return !Movement.Equals(Vector3.zero);
    }

    /**
     * Returns the movement.
     * @return movement of the object.
     */
    public Vector3 GetMovement()
    {
        return Movement;
    }
}
