using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherInLawController : MonoBehaviour
{
    [SerializeField]
    private GameObject ThePlayer;

    public bool Killing = false;

    private void Update()
    {
        if (Killing)
        {
            if (Utils.AnimationIsFinished(GetComponent<Animator>()))
            {
                Killing = false;
                ThePlayer.SendMessage("ChangeToDeath");
            }
        }
    }

    private void SetKilling(bool aKilling)
    {
        Killing = aKilling;
    }
}
