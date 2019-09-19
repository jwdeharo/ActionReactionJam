using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float fadeSpeed;
    private SpriteRenderer image;
    
    void Awake()
    {
        image = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Fade();
    }

    void Fade()
    {
        Color alpha = image.color;
        alpha.a += fadeSpeed;
        image.color = alpha;
        if (alpha.a >= 1)
        {
            alpha.a = 1;
            image.color = alpha;
            this.enabled = false;
        }
    }

}
