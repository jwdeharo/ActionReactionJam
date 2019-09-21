using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shake : MonoBehaviour
{
    public int intensity, duration;
    public AudioSource audioS;
    public AudioClip buzz;

    private bool isShaking;
    private Vector2 startPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(ShakeMobile());
            audioS.PlayOneShot(buzz);
            GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }

    public IEnumerator ShakeMobile()
    {
        int i = 0;
        while (i < duration)
        {
            this.transform.localPosition = new Vector2(startPosition.x +Random.Range(0, intensity), startPosition.y+ Random.Range(0, intensity));
            yield return new WaitForSeconds(0.01f);
            i++;
        }
        this.transform.localPosition = startPosition;
    }
}
