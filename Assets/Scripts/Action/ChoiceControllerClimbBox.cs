using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceControllerClimbBox : MonoBehaviour
{
    public GameObject box, boxInteract;
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
                canClimb = false;
            }
        }

        if (transform.position.y > -0.4)
        {
            print("El player esta encima de la caja");
            box.SendMessage("SetPlayerUp", true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            boxInteract.SetActive(false);
        }
        else
        {
            print("El player esta debajo de la caja");
            box.SendMessage("SetPlayerUp", false);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            boxInteract.SetActive(true);
        }
    }

    public void PerformAction()
    {
        SendMessage("ChangeToClimb", true);
    }
}
