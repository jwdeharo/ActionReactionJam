using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefighters : MonoBehaviour
{
    [SerializeField]
    private GameObject Target = null;
    public DeployChoices deployChoicesScript;
    public float speed = 0.12f;
    private float step;
    private bool CanMove = false;
    [SerializeField]
    private Vector3 target = new Vector3();
    [SerializeField]
    private GameObject busInteract;

    public void OnTriggerEnter2D(Collider2D aCollision)
    {
        if(aCollision.gameObject == Target)
        {
            deployChoicesScript.TwoChoices = true;
            //print(deployChoicesScript.TwoChoices);
        }
    }

    void Update()
    {
        if (CanMove)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (Vector3.Distance(transform.position, target) == 0.0f)
            {
                CanMove = false;
                GetComponent<Animator>().SetBool("canWalk", CanMove);
                busInteract.SetActive(true);
            }
        }
    }
    public void MoveFirefighter(bool aCanMove)
    {
        CanMove = aCanMove;
        GetComponent<SpriteRenderer>().flipX = true;
        GetComponent<Animator>().SetBool("canWalk",true);
        //GetComponent<ActionInteraction>().enabled = !aCanMove;
    }


}