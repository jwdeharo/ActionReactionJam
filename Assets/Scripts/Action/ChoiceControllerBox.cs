using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceControllerBox : ChoiceGeneral
{
    public GameObject box;

    protected override void PerformAction()
    {
        box.GetComponent<BoxCollider2D>().enabled = true;
        box.transform.position = new Vector2(box.transform.position.x, -0.57f);
        Destroy(transform.parent.gameObject);
    }
}
