using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneApps : MonoBehaviour
{
    public GameObject panel;
    public string appText;
    public AudioSource audioS;
    public AudioClip clip;

    private bool isCancel;
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate{
            ShowText(appText);
        });
    }

    private void ShowText(string text)
    {
        audioS.PlayOneShot(clip);
        panel.SetActive(true);
        panel.transform.GetChild(0).GetComponent<Text>().text = text;
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Cancel") != 0)
        {
            if (!isCancel)
            {
                panel.SetActive(false);
            }
        }
        else
        {
            isCancel = false;
        }
    }


}
