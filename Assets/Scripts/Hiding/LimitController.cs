using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitController : MonoBehaviour
{
    [SerializeField]
    private GameObject ViewFinder = null;

    private void OnTriggerEnter2D(Collider2D aCollision)
    {
        if (ViewFinder != null && aCollision.tag == "Player")
        {
            ViewFinder.GetComponent<ViewFinderController>().SetChaseSpeed(4.0f);
        }
    }
}
