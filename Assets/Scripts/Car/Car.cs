using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{


    private void OnCar(GameObject aGameObject)
    {
        if (aGameObject.GetComponent<PlayerController>().HasKey)
        {
            aGameObject.SendMessage("ChangeToDeath");
        }
        else
        {
            print("NO TIENES LAS LLAVES");
        }
    }
}
