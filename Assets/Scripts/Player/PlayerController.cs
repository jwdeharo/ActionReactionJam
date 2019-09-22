using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    public float MovingSpeedFactor = 1.0f;
    public float MoveSpeed = 5.0f;                  //!< Velocity of the player.
    public Animator Animator;                       //!< Animator which handles the animations.
    public bool FirekeepersSeen;

    private Sprite OriginalSprite;
    private Transform ToHideTransform;


    [SerializeField]
    private GameObject HidingSprite = null;

    [SerializeField]
    private bool Hide;
    private bool Wait;
    private bool BoxTransformation;
    private bool Dead = false;
    private bool BoxToPlayer;

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        IdleState MyIdleState = new IdleState();
        WalkingState WalkState = new WalkingState();
        DeathState MyDeathState = new DeathState();
        HidingState HideState = new HidingState();
        WaitingState MyWaitState = new WaitingState();
        BoxToPlayerState MyBoxToPlayerState = new BoxToPlayerState();

        MyIdleState.Init(this);
        WalkState.Init(this);
        MyDeathState.Init(this);
        HideState.Init(this);
        MyWaitState.Init(this);
        MyBoxToPlayerState.Init(this);

        States = new Dictionary<string, CState>();

        States.Add("Idle", MyIdleState);
        States.Add("Walk", WalkState);
        States.Add("Death", MyDeathState);
        States.Add("Hide", HideState);
        States.Add("Wait", MyWaitState);
        States.Add("BoxToPlayer", MyBoxToPlayerState);

        MyFSM = GetComponent<FSM>();
        MyFSM.StartFSM();
        MyFSM.ChangeState(MyIdleState);

        Hide = false;
        Wait = false;
        BoxTransformation = false;
        BoxToPlayer = false;

        OriginalSprite = GetComponent<SpriteRenderer>().sprite;
        Animator = GetComponent<Animator>();
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
            print("empujar");
            Animator.SetBool("isPushing", true);
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
            Animator.SetBool("isPushing", false);
            aCollision.gameObject.SendMessage("ApplyMovement", Vector3.zero);
            MovingSpeedFactor = 1.0f;
        }
    }

    public bool IsHiding()
    {
        return Hide;
    }

    public bool IsChangedSprite()
    {
        return BoxTransformation;
    }

    public bool IsBoxToPlayer()
    {
        return BoxToPlayer;
    }

    private void ChangeToDeath()
    {
        Dead = true;
    }

    public bool IsDead()
    {
        return Dead;
    }

    public bool IsWaiting()
    {
        return Wait;
    }

    public void SetBox(bool aBox)
    {
        BoxTransformation = aBox;
    }

    public void TimeToHide(GameObject aGameObject)
    {
        Hide = true;
        ToHideTransform = aGameObject.transform;
    }

    public void SetHide(bool aHide)
    {
        Hide = aHide;
    }

    public void SetBoxToPlayer(bool aBoxToPlayer)
    {
        BoxToPlayer = aBoxToPlayer;
    }

    public Transform GetToHideTransform()
    {
        return ToHideTransform;
    }

    public void ChangeSprite(bool aToOriginal)
    {
        Destroy(HidingSprite);
    }

    public void ToWait(bool aToWait)
    {
        Wait = aToWait;
    }
}
