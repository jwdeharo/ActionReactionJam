using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceControllerClimbBox : MonoBehaviour
{
    public BoxSwitchManager boxSwitchScript;
    public GameObject box;
    public float speed;
    public float targetY;
    
    private bool canClimb;

    private void Update()
    {
        if (canClimb)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(box.transform.position.x, targetY), speed * Time.deltaTime);
            if(Mathf.Approximately(transform.position.y, targetY)){
                GetComponent<Animator>().SetBool("climbBox", false);
                box.GetComponent<BoxCollider2D>().enabled = true;
                boxSwitchScript.CheckSwitchOff();
                canClimb = false;
            }
        }
    }

    public void PerformAction()
    {
        canClimb = true;
        GetComponent<Animator>().SetBool("climbBox", true);
        box.GetComponent<BoxCollider2D>().enabled = false;
    }
}
