using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlfriendController : MonoBehaviour
{

    public bool CanCheck = false;
    [SerializeField]
    PlayerController MyPlayerController = null;
    [SerializeField]
    GameObject MyKeys = null;
    // Update is called once per frame
    void Update()
    {
        if (CanCheck && Utils.AnimationIsFinished(GetComponent<Animator>()))
        {
            GetComponent<Animator>().SetBool("GiveKeys", false);
            MyPlayerController.ToWait(false);
            MyPlayerController.HasKey = true;
            MyKeys.SetActive(true);
            CanCheck = false;
        }
    }
}
