using UnityEngine;


    public class BalloonMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject Respawn = null;
    [SerializeField]
    private Vector3 target = new Vector3();

    private float speed = 0.12f;
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
                CanMove = false;
            }
        }
    }

    public void MoveBalloon(bool aCanMove)
    {
        CanMove = aCanMove;
        GetComponent<ActionInteraction>().enabled = !aCanMove;
    }
}