using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            print("Has pulsado escape");
            SceneManager.LoadScene("Juego");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Has pulsado escape");
            Application.Quit();
        }
    }
}
