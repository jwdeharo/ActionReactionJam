using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class BalloonMovement : MonoBehaviour
{
    private float speed = 0.12f;
    private Vector2 target;
    private Vector2 position;
    private float step;

    public void MoveBalloon(bool CanMove)
    {
        if (CanMove && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Se mueve");
            var respawn = GameObject.FindWithTag("Balloon");
            position = respawn.transform.position;
            Debug.Log("Se mueve");
            target = new Vector2(0.236f, 0.696f);
            step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
    }
}