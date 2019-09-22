
using UnityEngine;

public class ClimbingBoxState : CState
{
    private PlayerController MyPlayerController;
    private GameObject BoxToClimb;
    private bool CanClimb;
    private const float TargetY = -0.32f;
    private const float Speed = 2.0f;

    public override void Init(BaseController aParent)
    {
        base.Init(aParent);
        MyPlayerController = (PlayerController)Controller;
        BoxToClimb = MyPlayerController.GetClimbingBox();
    }

    public override void OnEnterState()
    {
        Controller.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        Controller.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        CanClimb = true;
        Controller.GetComponent<Animator>().SetBool("climbBox", true);
        BoxToClimb.GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void UpdateState()
    {
        if (CanClimb)
        {
            Controller.transform.position = Vector2.MoveTowards(Controller.transform.position, new Vector2(BoxToClimb.transform.position.x, TargetY), Speed * Time.deltaTime);
            if (Mathf.Approximately(Controller.transform.position.y, TargetY))
            {
                Controller.GetComponent<Animator>().SetBool("climbBox", false);
                BoxToClimb.GetComponent<BoxCollider2D>().enabled = true;
                CanClimb = false;
                Controller.GetFSM().PopState();
                Controller.SendMessage("ChangeToClimb", false);
            }
        }
    }
}
