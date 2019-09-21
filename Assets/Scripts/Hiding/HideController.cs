using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideController : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;


    private void OnTriggerStay2D(Collider2D aCollision)
    {
        if (aCollision.gameObject == Target && Input.GetKeyDown(KeyCode.E))
        {
            Target.SendMessage("TimeToHide", gameObject);
        }
    }
}
