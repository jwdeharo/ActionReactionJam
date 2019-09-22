using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Flickering flickeringKeys;

    private void OnCar(GameObject aGameObject)
    {
        if (aGameObject.GetComponent<PlayerController>().HasKey)
        {
            aGameObject.SendMessage("ChangeToDeath");
        }
        else
        {
            print("no hay llaves");
            StartCoroutine(flickeringKeys.Flick());
        }
    }
}
