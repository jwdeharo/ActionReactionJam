using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MyPlayer = null;

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
                if (MyPlayer != null)
                {
                    MyPlayer.GetComponent<PlayerController>().SetWaiting(true);
                }

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
