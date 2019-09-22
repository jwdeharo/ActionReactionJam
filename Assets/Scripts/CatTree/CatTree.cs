using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTree : MonoBehaviour
{
    public void Cat()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().TakeBalloon)
        {
            //Puedes subir a por el gato pero no llamar a los bomberos.

            if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().FirekeepersSeen)
            {
                //Pueds subir a por el gato o llamar a los bomberos
            }
        }
    }
}
