using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    public float MovingSpeedFactor = 1.0f;
    public float MoveSpeed = 5.0f;                  //!< Velocity of the player.
    public Animator Animator;                       //!< Animator which handles the animations.
    private Sprite OriginalSprite;

    [SerializeField]
    private GameObject HidingSprite;

    [SerializeField]
    private bool Hide;

    private bool Dead = false;

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        IdleState MyIdleState = new IdleState();
        WalkingState WalkState = new WalkingState();
        DeathState MyDeathState = new DeathState();

        MyIdleState.Init(this);
        WalkState.Init(this);
        MyDeathState.Init(this);

        States = new Dictionary<string, CState>();

        States.Add("Idle", MyIdleState);
        States.Add("Walk", WalkState);
        States.Add("Death", MyDeathState);

        MyFSM = GetComponent<FSM>();
        MyFSM.StartFSM();
        MyFSM.ChangeState(MyIdleState);
        Hide = false;

        OriginalSprite = GetComponent<SpriteRenderer>().sprite;
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

    public bool IsHiding()
    {
        return Hide;
    }

    private void ChangeToDeath()
    {
        Dead = true;
    }

    public bool IsDead()
    {
        return Dead;
    }

    public void TimeToHide(bool aCanHide)
    {
        Hide = aCanHide;
        GetComponent<Animator>().enabled = !aCanHide;
        GetComponent<SpriteRenderer>().sprite = aCanHide ? HidingSprite.GetComponent<SpriteRenderer>().sprite : OriginalSprite;
    }
}
