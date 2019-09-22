using UnityEngine;

public class FatherInLawController : MonoBehaviour
{
    [SerializeField]
    private GameObject ThePlayer;
    public AudioSource audioS;
    public AudioClip piu;


    public bool Killing = false;

    private void FixedUpdate()
    {
        if (Killing)
        {
            if (Utils.AnimationIsFinished(gameObject.GetComponent<Animator>()))
            {
                audioS.PlayOneShot(piu);
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
