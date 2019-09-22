using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour
{
    public AudioSource audioS;
    private bool isFire;

    void Update()
    {

        if (Input.GetAxisRaw("Submit") != 0)
        {
            if (!isFire)
            {
                isFire = true;
                StartCoroutine(LowVolume());
            }
        }
        else
        {
            isFire = false;
        }

    }

    public IEnumerator LowVolume()
    {
        while (audioS.volume > 0)
        {
            audioS.volume -= 0.01f;
            yield return null;
        }
        if (audioS.volume == 0)
        {
            audioS.clip = null;
            audioS.volume = 1;
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
