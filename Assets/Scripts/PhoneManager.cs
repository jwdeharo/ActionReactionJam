using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public GameObject bigPhone;
    public AudioSource audioS;
    public AudioClip clip;

    private bool isFire;

    private void Update()
    {
        if (Input.GetAxisRaw("Jump") != 0)
        {
            if (!isFire)
            {
                isFire = true;
                audioS.PlayOneShot(clip);
                bigPhone.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        else
        {
            isFire = false;
        }
    }
   
}
