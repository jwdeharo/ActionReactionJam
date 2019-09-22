﻿using UnityEngine;

public class ChoiceControllerBox : MonoBehaviour
{
   // public BoxSwitchManager boxSwitchScript;
    public Rigidbody2D playerBody;

    public void PerformAction()
    {
        //boxSwitchScript.InitializePositions();
        GetComponent<BoxCollider2D>().enabled = true;
        transform.position = new Vector2(transform.position.x, -0.57f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerBody.constraints = RigidbodyConstraints2D.None;
        }
    }
}
