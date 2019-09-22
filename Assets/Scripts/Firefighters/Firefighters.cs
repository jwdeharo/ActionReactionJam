using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefighters : MonoBehaviour
{
    [SerializeField]
    private GameObject Target = null;
    public DeployChoices deployChoicesScript;
    private float speed = 0.12f;
    private Vector3 position;
    private float step;
    private bool CanMove = false;
    [SerializeField]
    private Vector3 target = new Vector3();

    public void OnTriggerEnter2D(Collider2D aCollision)
    {
        if(aCollision.gameObject == Target)
        {
            deployChoicesScript.TwoChoices = true;
            print("two="+deployChoicesScript.TwoChoices);
        }
    }

    void Update()
    {
        if (CanMove)
        {
            position = GameObject.FindWithTag("Firefighter").transform.position;
            print(position);
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            print(transform.position = Vector3.MoveTowards(transform.position, target, step));

            if (Vector3.Distance(transform.position, target) == 0.0f)
            {
                CanMove = false;
            }
        }
    }
    public void MoveFirefighter(bool aCanMove)
    {
        CanMove = aCanMove;
        GetComponent<ActionInteraction>().enabled = !aCanMove;
    }


}