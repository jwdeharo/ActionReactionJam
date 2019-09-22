using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    private void OnBus(GameObject aGameObject)
    {
        if (aGameObject.GetComponent<PlayerController>().HasWallet)
        {
            print("HAS GANADO");
        }
        else
        {
            print("NO TIENES LA CARTERA");
        }
    }
}
