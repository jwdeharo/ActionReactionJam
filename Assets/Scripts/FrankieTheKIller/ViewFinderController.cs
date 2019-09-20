using System.Collections.Generic;
using UnityEngine;

public class ViewFinderController : BaseController
{
    private bool FirstTimeTrigger;
    private SpriteRenderer MySpriteRenderer;

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
    }

    private void StartChasing()
    {
        if (FirstTimeTrigger)
        {
            MySpriteRenderer.enabled = true;
            FirstTimeTrigger = false;

            MyFSM.SetActive(true);
            MyFSM.ChangeState(States["Idle"]);
        }
    }

    private void StopChasing()
    {
        MySpriteRenderer.enabled = false;
        FirstTimeTrigger = true;
        MyFSM.SetActive(false);
    }
}
