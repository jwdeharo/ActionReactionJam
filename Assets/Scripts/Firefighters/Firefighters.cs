using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefighters : MonoBehaviour
{
    [SerializeField]
    private GameObject Target = null;
    //public PlayerController player;

    public void OnTriggerEnter2D(Collider2D aCollision)
    {
        if(aCollision.gameObject == Target)
        {
           aCollision.gameObject.GetComponent<PlayerController>().FirekeepersSeen = true;
           print(aCollision.gameObject.GetComponent<PlayerController>().FirekeepersSeen);
        }
    }
}