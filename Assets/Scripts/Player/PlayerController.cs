using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    public float MovingSpeedFactor = 1.0f;
    public float MoveSpeed = 5.0f;                  //!< Velocity of the player.
    public Animator Animator;                       //!< Animator which handles the animations.
    private Transform ToHideTransform;

    [SerializeField]
    private GameObject HidingSprite     = null;
    [SerializeField]
    private GameObject YouShallNotPass  = null;
    [SerializeField]
    private GameObject BoxToClimb       = null;

    private bool Hide;
    private bool Wait;
    private bool BoxTransformation;
    private bool Dead;
    private bool Climb;
    private bool BoxToPlayer;

    private bool firekeepersSeen = false;
    private bool takeBalloon = false;
    private bool hasKey = false;
    private bool hasWallet = false;
    public bool FirekeepersSeen { get => firekeepersSeen; set => firekeepersSeen = value; }
    public bool TakeBalloon { get => takeBalloon; set => takeBalloon = value; }
    public bool HasKey { get => hasKey; set => hasKey = value; }
    public bool HasWallet { get => hasWallet; set => hasWallet = value; }
    
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
        ClimbingBoxState ClimbState = new ClimbingBoxState();

        MyIdleState.Init(this);
        WalkState.Init(this);
        MyDeathState.Init(this);
        HideState.Init(this);
        MyWaitState.Init(this);
        MyBoxToPlayerState.Init(this);
        ClimbState.Init(this);

        States = new Dictionary<string, CState>();

        States.Add("Idle", MyIdleState);
        States.Add("Walk", WalkState);
        States.Add("Death", MyDeathState);
        States.Add("Hide", HideState);
        States.Add("Wait", MyWaitState);
        States.Add("BoxToPlayer", MyBoxToPlayerState);
        States.Add("Climb", ClimbState);

        MyFSM = GetComponent<FSM>();
        MyFSM.StartFSM();
        MyFSM.ChangeState(MyIdleState);

        Dead                = false;
        Hide                = false;
        Climb               = false;
        Wait                = false;
        BoxTransformation   = false;
        BoxToPlayer         = false;
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
            MovingSpeedFactor = aCollision.gameObject.GetComponent<MovableObjectsController>().IsPlayerUp() ? 1.0f : 0.1f;
            aCollision.gameObject.SendMessage("ApplyMovement", aCollision.gameObject.GetComponent<MovableObjectsController>().IsPlayerUp() ? Vector3.zero : GetMovement());
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
            aCollision.gameObject.SendMessage("ApplyMovement", Vector3.zero);
            MovingSpeedFactor = 1.0f;
        }
    }

    /**
     * Returns if the player is hiding.
     * @return true if hiding, false if not.
     */
    public bool IsHiding()
    {
        return Hide;
    }

    /**
     * Returns the box to climb.
     * @return box to climb.
     */
    public GameObject GetClimbingBox()
    {
        return BoxToClimb;
    }

    /**
     * Returns if the player is using another sprite.
     * @return true if using another sprite, false if not.
     */
    public bool IsChangedSprite()
    {
        return BoxTransformation;
    }

    /**
     * Returns if the player is changing from box to player.
     * @return true if changing from box to player, false if not.
     */
    public bool IsBoxToPlayer()
    {
        return BoxToPlayer;
    }

    /**
     * Change the var Dead to true.
     */
    private void ChangeToDeath()
    {
        Dead = true;
    }

    /**
     * Sets the var climb to a new value.
     * @param aClimb new value.
     */
    private void ChangeToClimb(bool aClimb)
    {
        Climb = aClimb;
    }

    /**
     * Returns if the player is dead.
     * @return true if dead, false if not.
     */
    public bool IsDead()
    {
        return Dead;
    }

    public bool IsClimbing()
    {
        return Climb;
    }

    /**
     * Returns if the player is waiting or not.
     * @param true if waiting, false if not.
     */
    public bool IsWaiting()
    {
        return Wait;
    }

    /**
     * Sets the var Boxtransformation.
     * @param aBox new value.
     */
    public void SetBox(bool aBox)
    {
        BoxTransformation = aBox;
    }

    /**
     * Sets the var hide to true.
     * @param Game object to set.
     */
    public void TimeToHide(GameObject aGameObject)
    {
        Hide = true;
        ToHideTransform = aGameObject.transform;
        YouShallNotPass.SendMessage("ActiveYouShallNotPass", true);
    }

    /**
     * Sets the var hide to a new value.
     * @param aHide new value.
     */
    public void SetHide(bool aHide)
    {
        Hide = aHide;
    }

    /**
     * Sets the var BoxToPlayer to a new value.
     * @param aBoxToPlayer new value.
     */
    public void SetBoxToPlayer(bool aBoxToPlayer)
    {
        BoxToPlayer = aBoxToPlayer;
    }

    /**
     * Destroys the previous sprite.
     */
    public void ChangeSprite()
    {
        Destroy(HidingSprite);
    }

    /**
     * Sets the var Wait to a new value.
     * @param aToWait new value.
     */
    public void ToWait(bool aToWait)
    {
        Wait = aToWait;
    }
}
