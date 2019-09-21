using UnityEngine;

public class FrankieController : MonoBehaviour
{

    [SerializeField]
    private GameObject ViewFinder = null;
    private bool Active = true;

    private void OnTriggerEnter2D(Collider2D aCollision)
    {
        if (Active)
        {
            if (aCollision.tag == "Player")
            {
                aCollision.gameObject.SendMessage("ToWait", true);
                ViewFinder.SendMessage("StartChasing");
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
