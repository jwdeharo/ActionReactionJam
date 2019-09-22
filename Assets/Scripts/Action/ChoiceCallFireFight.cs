using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCallFireFight : ChoiceGeneral
{
    public Firefighters fire;
    public GameObject interact;

    protected override void PerformAction()
    {
        fire.MoveFirefighter(true);
        if (MustDestroy)
        {
            Destroy(interact);
        }
    }

}