using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    SpriteRenderer spriteR;
    WaitForSeconds wait;
    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        wait = new WaitForSeconds(0.5f);
    }

    public IEnumerator Flick()
    {
        for (int i = 0; i < 3; i++)
        {
            print("flik");
            yield return wait;
            spriteR.enabled=true;
            yield return wait;
            spriteR.enabled = false;
            print("flok");
        }
        
    }

}
