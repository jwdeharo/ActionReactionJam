using UnityEngine;


public class BalloonMovement : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip clip;
    public GameObject gato;

    [SerializeField]
    private GameObject Respawn = null;
    [SerializeField]
    private Vector3 target = new Vector3();
    [SerializeField]
    private GameObject interactCat;

    private float speed = 0.52f;
    private Vector3 position;
    private float step;
    private bool CanMove = false;

    public void Update()
    {
        if (CanMove)
        {
            position = Respawn.transform.position;
            step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);

            if (Vector3.Distance(transform.position, target) == 0.0f)
            {
                audioS.PlayOneShot(clipCat);
                gato.SetActive(true);
                CanMove = false;
                interactCat.SetActive(true);
            }
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().TakeBalloon = true;
        }
    }

    public void MoveBalloon(bool aCanMove)
    {
        audioS.PlayOneShot(clip);
        CanMove = aCanMove;
        GetComponent<Animator>().SetBool("isMoving", true);
        GetComponent<ActionInteraction>().enabled = !aCanMove;
    }
}