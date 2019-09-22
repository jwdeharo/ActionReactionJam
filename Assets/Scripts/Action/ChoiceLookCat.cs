using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceLookCat : ChoiceGeneral
{
    protected override void PerformAction()
    {
        print("Mueres por el gato");
        GameObject.FindWithTag("Player").SendMessage("ChangeToDeath");
        
    }
}
