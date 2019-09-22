using System.Collections.Generic;
using UnityEngine;

public class MovableObjectsController : BaseController
{
    [SerializeField]
    private Transform ThrowPosition;
    [SerializeField]
    private float ThrowSpeed;
    [SerializeField]
    private GameObject FatherInLaw;

    private Vector3 Movement; //!< Movement of the movable object.
    private bool PlayerUp;
    private bool Throwing;
    public AudioSource audioS;
    public AudioClip clip;

    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        MovableObjectIdleState IdleState = new MovableObjectIdleState();
        MovableObjectsMoveState MoveState = new MovableObjectsMoveState();
        MovableObjectThrowState ThrowState = new MovableObjectThrowState();

        IdleState.Init(this);
        MoveState.Init(this);
        ThrowState.Init(this);

        States = new Dictionary<string, CState>();
        States.Add("Idle", IdleState);
        States.Add("Move", MoveState);
        States.Add("Throw", ThrowState);

        Movement = new Vector3();

        MyFSM = GetComponent<FSM>();
        MyFSM.StartFSM();
        MyFSM.ChangeState(IdleState);

        PlayerUp = false;
        Throwing = false;
    }

    public void DestroyMovableObject()
    {
        Destroy(this.gameObject);
    }

    public bool IsThrowing()
    {
        return Throwing;
    }

    public void PlayDestroy()
    {
        audioS.PlayOneShot(clip);
    }

    public bool IsPlayingSound()
    {
        return audioS.isPlaying;
    }

    public void SetThrowing(bool aThrowing)
    {
        Throwing = aThrowing;
    }

    public void TimeToKillAnim(bool aToKill)
    {
        FatherInLaw.GetComponent<Animator>().SetBool("TimeToKill", aToKill);
        FatherInLaw.SendMessage("SetKilling", aToKill);
    }

    public void SetPlayerUp(bool aPlayerUp)
    {
        PlayerUp = aPlayerUp;
    }

    public bool IsPlayerUp()
    {
        return PlayerUp;
    }

    public Vector3 GetThrowingPosition()
    {
        return ThrowPosition.position;
    }

    public float GetThrowSpeed()
    {
        return ThrowSpeed;
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
