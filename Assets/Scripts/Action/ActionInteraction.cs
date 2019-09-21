using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInteraction : MonoBehaviour
{
    public Animator anim;
    public AudioClip[] actionSnd;
    public AudioSource audioS;
    public GameObject[] choices;
    public DeployChoices deployChoicesScript;

    private bool canInteract, isFire;
   
    private void Update()
    {
        
        if (Input.GetAxisRaw("Fire1") != 0 && canInteract)
        {
            if (!isFire)
            {
                isFire = true;
                deployChoicesScript.ShowChoices(choices);
                VanishAnimation();
            }
        }
        else
        {
            isFire = false;
        }
    }

    /*
     * When player hits interactable object animation pops up 
     * and is possible to interact with it
     */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canInteract = true;
            anim.gameObject.SetActive(false);
            anim.gameObject.SetActive(true);
            audioS.PlayOneShot(actionSnd[Random.Range(0,actionSnd.Length)]);
        }
    }

    /*
     * When player leaves the collider tha nimation dissapears
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canInteract = false;
            VanishAnimation();
            deployChoicesScript.DeactivateChoices(choices);
        }
    }

    private void VanishAnimation()
    {
        anim.SetBool("canContinue", true);
    }

   
}
