using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbTree : MonoBehaviour
{
    public Animator catAnim;
    public float speed;
    public AudioSource audioS;
    public AudioClip clip;


    private bool climb, catchCat;
    private Vector2 targetX, targetY;
    private Animator playerAnim;
    private SpriteRenderer playerRender;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRender= GetComponent<SpriteRenderer>();
        climb = false;
        catchCat = false;
        targetX = new Vector2(-0.848f, transform.position.y);
        targetY = new Vector2(-1.194f, - 0.55f);
    }

    private void Update()
    {
        if (climb)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetX, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetX) == 0.0f)
            {
                playerAnim.SetBool("climbTree", true);
                climb = false;
                audioS.PlayOneShot(clip);
                catAnim.SetBool("isEvil", true);
                playerAnim.SetBool("treeTop", true);
                catchCat = true;
            }
        }
        if (catchCat) {

            transform.position = Vector2.MoveTowards(transform.position, targetY, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetY) == 0.0f)
            {
                gameObject.SendMessage("ChangeToDeath");
            }
        }
        
    }

    public void StartAction()
    {
        gameObject.SendMessage("ToWait",true);
        playerRender.sortingOrder = 5;
        climb = true;
    }
}
