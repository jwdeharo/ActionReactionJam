using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherInLawController : MonoBehaviour
{
    [SerializeField]
    private GameObject MyPlayer = null;
    private bool IsExploding = false;
    public AudioSource audioS;
    public AudioClip clip;

    private void FixedUpdate()
    {
        if (IsExploding)
        {
            if (Utils.AnimationIsFinished(GetComponent<Animator>()))
            {
                MyPlayer.SendMessage("ChangeToDeath");
            }
        }
    }

    private void ExplosingEntrance()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animator>().SetBool("IsExploding", true);
        audioS.PlayOneShot(clip);
        IsExploding = true;
    }

}
