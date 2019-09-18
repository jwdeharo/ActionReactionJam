using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    public float MovingSpeedFactor = 1.0f;
    public float MoveSpeed = 5.0f;                  //!< Velocity of the player.
    public Animator Animator;                       //!< Animator which handles the animations.
    public bool ToOne = false;

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        IdleState IdleState = new IdleState();
        WalkingState WalkState = new WalkingState();

        IdleState.Init(this);
        WalkState.Init(this);

        States = new Dictionary<string, CState>();

        States.Add("Idle", IdleState);
        States.Add("Walk", WalkState);
        MyFSM = GetComponent<FSM>();
        MyFSM.StartFSM();
        MyFSM.ChangeState(IdleState);
    }

    /**
     * Returns the movement of the player based on the horizontal axis.
     * @return movement based on the horizontal axis.
     */
    public Vector3 GetMovement()
    {
        Vector3 Movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f);
        return Movement * Time.deltaTime * MoveSpeed * MovingSpeedFactor;
    }

    /**
     *  Indicates if the object with which we have collided is T or not.
     *  @param aCollision: collision detected.
     *  @return bool if the object is of type T.
     */
    public bool IsTypeObject<T>(Collision2D aCollision)
    {
        bool ReturnValue = false;

        if (aCollision.gameObject != null)
        {
            T TypeObject = aCollision.gameObject.GetComponent<T>();

            if (TypeObject != null)
            {
                ReturnValue = true;
            }
        }

        return ReturnValue;
    }

    /**
     * Event called when the object enters a 2d collision.
     * @param aCollision: collision detected.
     */
    private void OnCollisionEnter2D(Collision2D aCollision)
    {
        if (IsTypeObject<MovableObjectsController>(aCollision) && GetMovement().x != 0.0f)
        {
            MovingSpeedFactor = 0.1f;
            aCollision.gameObject.SendMessage("ApplyMovement", GetMovement());
        }
    }

    /**
     * Event called when the object exits a 2d collision.
     * @param aCollision: collision detected.
     */
    private void OnCollisionExit2D(Collision2D aCollision)
    {
        if (IsTypeObject<MovableObjectsController>(aCollision))
        {
            aCollision.gameObject.SendMessage("ApplyMovement", GetMovement());
            MovingSpeedFactor = 1.0f;
        }
    }
}
