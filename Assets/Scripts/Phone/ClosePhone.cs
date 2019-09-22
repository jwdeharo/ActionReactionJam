using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePhone : MonoBehaviour
{
    public GameObject phoneBig, phoneSmall;
    public AudioSource audioS;
    public AudioClip clip;

    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Close);
    }

    public void Close()
    {
        audioS.PlayOneShot(clip);
        phoneBig.SetActive(false);
        phoneSmall.SetActive(true);
    }
}
