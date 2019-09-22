using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public int times;

    WaitForSeconds wait;
    
    private void Start()
    {
        wait = new WaitForSeconds(0.5f);
    }

    public IEnumerator Flick()
    {
        for (int i = 0; i < times; i++)
        {
            print("flick");
            yield return wait;
            gameObject.GetComponent<SpriteRenderer>().enabled=true;
            yield return wait;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            print("flock");
        }
        
    }

}
