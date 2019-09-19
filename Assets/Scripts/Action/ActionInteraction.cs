using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInteraction : MonoBehaviour
{
    public Animator anim;
    public AudioClip[] actionSnd;
    public AudioSource audioS;
    public GameObject[] choices;
    public float speed;

    private Vector2 initialPosition;
    private bool canInteract, isFire;
    private float step;
    private Vector2 newPosition;

    private void Awake()
    {
        initialPosition = new Vector2(0, 0.75f);
    }

    private void Update()
    {
        step= speed * Time.deltaTime;
        if (Input.GetAxisRaw("Fire1") != 0 && canInteract)
        {
            if (!isFire)
            {
                isFire = true;
                ShowChoices();
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
            DeactivateChoices();
        }
    }

    private void VanishAnimation()
    {
        anim.SetBool("canContinue", true);
    }

    private void ShowChoices()
    {
        newPosition = new Vector2(initialPosition.x + 0.5f, initialPosition.y);

        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(true);
            if (i != 0)
            {
                if (i % 2 == 0)
                    StartCoroutine(SpreadChoicesRight(i));
                else
                    StartCoroutine(SpreadChoicesLeft(i));
            }
        }
    }

    private void DeactivateChoices()
    {
        for(int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }
    }

    IEnumerator SpreadChoicesRight(int index)
    {
        while (choices[index].transform.localPosition.x < newPosition.x) {
            choices[index].transform.localPosition  = new Vector2(choices[index].transform.localPosition.x + step, choices[index].transform.localPosition.y);
            
            yield return null;
        }
        choices[index].transform.localPosition = newPosition;
    }

    IEnumerator SpreadChoicesLeft(int index)
    {
        while (choices[index].transform.localPosition.x > -newPosition.x){
            choices[index].transform.localPosition = new Vector2(choices[index].transform.localPosition.x - step, choices[index].transform.localPosition.y);
           
            yield return null;
        }
        choices[index].transform.localPosition = new Vector2(-newPosition.x, choices[index].transform.localPosition.y);
    }
}
