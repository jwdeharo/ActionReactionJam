using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip clip;
    public Flickering flickeringKeys;

    private void OnCar(GameObject aGameObject)
    {
        if (aGameObject.GetComponent<PlayerController>().HasKey)
        {
            aGameObject.SendMessage("ChangeToDeath");
        }
        else
        {
            audioS.PlayOneShot(clip);
            StartCoroutine(flickeringKeys.Flick());
        }
    }
}
