using UnityEngine;

public class HideController : MonoBehaviour
{
    [SerializeField]
    private GameObject Target = null;
    [SerializeField]
    private GameObject YouShallNotPass = null;

    private void OnTriggerStay2D(Collider2D aCollision)
    {
        if (aCollision.gameObject == Target && Input.GetKeyDown(KeyCode.E))
        {
            Target.SendMessage("TimeToHide", gameObject);
        }
    }
}
