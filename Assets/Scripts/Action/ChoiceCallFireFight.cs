using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCallFireFight : ChoiceGeneral
{
    public Firefighters fire;
    protected override void PerformAction()
    {
        fire.MoveFirefighter(true);
    }

}