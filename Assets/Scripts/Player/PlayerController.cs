using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FSM MyFSM;
    // Start is called before the first frame update
    void Start()
    {
        IdleState IdleState = new IdleState();
        IdleState.Init(this);
        MyFSM = GetComponent<FSM>();
        MyFSM.StartFSM();
        MyFSM.ChangeState(IdleState, true);
    }
}
