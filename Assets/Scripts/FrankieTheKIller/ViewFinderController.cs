﻿using System.Collections.Generic;
using UnityEngine;

public class ViewFinderController : BaseController
{
    private bool            FirstTimeTrigger;
    private float Angle = 0.0f;

    private SpriteRenderer  MySpriteRenderer;
    private BoxCollider2D   MyCollider;

    [SerializeField]
    private GameObject      Target;
    [SerializeField]
    private float AngularSpeed = 1.0f;
    [SerializeField]
    private float RotationRadius = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        FrankieTheKillerIdleState IdleState = new FrankieTheKillerIdleState();
        IdleState.Init(this);

        States = new Dictionary<string, CState>();
        States.Add("Idle", IdleState);

        MyFSM = GetComponent<FSM>();
        MyFSM.StartFSM();

        FirstTimeTrigger = true;
        MySpriteRenderer = GetComponent<SpriteRenderer>();
        MyCollider = GetComponent<BoxCollider2D>();
    }

    private void StartChasing()
    {
        if (FirstTimeTrigger)
        {
            MySpriteRenderer.enabled = true;
            MyCollider.enabled = true;
            FirstTimeTrigger = false;

            MyFSM.SetActive(true);
            MyFSM.ChangeState(States["Idle"]);
        }
    }

    private void StopChasing()
    {
        MySpriteRenderer.enabled = false;
        MyCollider.enabled = false;

        FirstTimeTrigger = true;
        MyFSM.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D aCollision)
    {
        if (aCollision.gameObject == Target)
        {
            Target.SendMessage("ChangeToDeath");
        }
    }

    private float GetPosition(float aPosition, float aMathFAngle)
    {
        return aPosition + (aMathFAngle * RotationRadius);
    }

    public void CircleMovement()
    {
        transform.position = new Vector3(GetPosition(transform.position.x, Mathf.Cos(Angle)), 
            GetPosition(transform.position.y, Mathf.Sin(Angle)), 0.0f);

        Angle += Time.deltaTime * AngularSpeed;

        if (Angle > 360.0f)
        {
            Angle = 0.0f;
        }
    }
}
