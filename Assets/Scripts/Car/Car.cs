using UnityEngine;

public class Car : MonoBehaviour
{

    public Flickering flickeringKeys;
    private bool CanCheck = false;
    private GameObject ThePlayer;
    public AudioSource audioS;
    public AudioClip clip;

    private void FixedUpdate()
    {
        if (CanCheck && Utils.AnimationIsFinished(GetComponent<Animator>()))
        {
            CanCheck = false;
            ThePlayer.SendMessage("ChangeToDeath");
            GetComponent<Animator>().SetBool("Exploding", false);
            Destroy(gameObject);
        }
    }

    private void OnCar(GameObject aGameObject)
    {
        if (aGameObject.GetComponent<PlayerController>().HasKey)
        {
            CanCheck = true;
            GetComponent<Animator>().SetBool("Exploding", true);
            audioS.PlayOneShot(clip);
            ThePlayer = aGameObject;
        }
        else
        {
            StartCoroutine(flickeringKeys.Flick());
        }
    }
}
