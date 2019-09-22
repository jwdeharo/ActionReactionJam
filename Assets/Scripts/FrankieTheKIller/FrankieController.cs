using UnityEngine;

public class FrankieController : MonoBehaviour
{

    [SerializeField]
    private GameObject ViewFinder = null;
    [SerializeField]
    private GameObject FrankieTheMan = null;

    private GameObject ThePlayer;
    private bool Active = true;
    private bool FranchyWatching = false;

    private void Update()
    {
        if (Active && FranchyWatching)
        {
            if (Utils.AnimationIsFinished(FrankieTheMan.GetComponent<Animator>()))
            {
                ViewFinder.SendMessage("StartChasing");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D aCollision)
    {
        if (Active)
        {
            if (aCollision.tag == "Player")
            {
                ThePlayer = aCollision.gameObject;
                aCollision.gameObject.SendMessage("ToWait", true);
                FrankieTheMan.GetComponent<Animator>().SetBool("IsWatching", true);
                FranchyWatching = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D aCollision)
    {
        if (Active)
        {
            if (aCollision.tag == "Player")
            {
                ViewFinder.SendMessage("StopChasing");

                PlayerController MyPlayerController = aCollision.gameObject.GetComponent<PlayerController>();
                if (MyPlayerController != null && MyPlayerController.IsHiding())
                {
                    aCollision.gameObject.SendMessage("ChangeSprite", true);
                    aCollision.gameObject.SendMessage("SetHide", false);
                    MyPlayerController.Animator.SetBool("TurningBox", false);
                    MyPlayerController.Animator.SetBool("AlreadyTurned", false);
                    MyPlayerController.Animator.SetFloat("SpeedBox", -1.0f);
                    MyPlayerController.SetBoxToPlayer(true);

                    Active = false;
                }
            }
        }
    }
}
