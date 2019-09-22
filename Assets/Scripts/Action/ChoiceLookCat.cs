using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceLookCat : ChoiceGeneral
{
    public PlayerClimbTree playerClimbScript;
    public GameObject action;

    protected override void PerformAction()
    {
        playerClimbScript.StartAction();
        if (MustDestroy)
        {
            Destroy(action);
        }

    }
}
