using UnityEngine;

public class FrankieController : MonoBehaviour
{

    [SerializeField]
    private GameObject ViewFinder = null;

    private void OnTriggerEnter2D(Collider2D aCollision)
    {
        if (aCollision.tag == "Player")
        {
            aCollision.gameObject.SendMessage("ToWait", true);
            ViewFinder.SendMessage("StartChasing");
        }
    }

    private void OnTriggerExit2D(Collider2D aCollision)
    {
        if (aCollision.tag == "Player")
        {
            ViewFinder.SendMessage("StopChasing");

            PlayerController MyPlayerController = aCollision.gameObject.GetComponent<PlayerController>();
            if (MyPlayerController != null && MyPlayerController.IsHiding())
            {
                aCollision.gameObject.SendMessage("ChangeSprite", true);
                aCollision.gameObject.SendMessage("SetHide", false);
            }
        }
    }
}
