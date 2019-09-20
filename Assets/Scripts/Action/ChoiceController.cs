using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceController : MonoBehaviour
{
    private bool isFire;
    private void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0 && GetComponent<SpriteRenderer>().color.a==1)
        {
            if (!isFire)
            {
                isFire = true;
                print("Esta eleccion hace algo");
            }
        }
        else
        {
            isFire = false;
        }
    }
}
