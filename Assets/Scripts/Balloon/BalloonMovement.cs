using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    private float speed = 0.12f;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;
    private bool aux = false;

    void Start()
    {
        position = gameObject.transform.position;
    }

    void Update()
    {
        target = new Vector2(0.236f, 0.696f);
        float step = speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.L)) {
            aux = true;
        }
        if (aux)
        {
            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
    }

}