using UnityEngine;

public class YouShallNotPassController : MonoBehaviour
{
    [SerializeField]
    private GameObject ThePlayer;

    private PlayerController ThePlayerController;
    private BoxCollider2D MyCollider2D;

    private void Start()
    {
        ThePlayerController = ThePlayer.GetComponent<PlayerController>();
        MyCollider2D = GetComponent<BoxCollider2D>();
    }

    private void ActiveYouShallNotPass(bool aEnabled)
    {
        MyCollider2D.enabled = aEnabled;
    }
}
