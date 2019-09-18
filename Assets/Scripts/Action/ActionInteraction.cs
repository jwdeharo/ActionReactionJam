using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInteraction : MonoBehaviour
{
    public Animator anim;
    public AudioClip[] actionSnd;
    public AudioSource audioS;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.gameObject.SetActive(false);
            anim.gameObject.SetActive(true);
            audioS.PlayOneShot(actionSnd[Random.Range(0,actionSnd.Length)]);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            anim.SetBool("canContinue", true);
        
    }
}
