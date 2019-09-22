using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour
{
    private bool isFire;
    void Update()
    {

        if (Input.GetAxisRaw("Submit") != 0)
        {
            if (!isFire)
            {
                isFire = true;
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
        else
        {
            isFire = false;
        }

    }
}
