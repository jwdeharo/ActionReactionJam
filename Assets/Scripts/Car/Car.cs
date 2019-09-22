using UnityEngine;

public class Car : MonoBehaviour
{

    public Flickering flickeringKeys;
    private bool CanCheck = false;
    private GameObject ThePlayer;

    private void FixedUpdate()
    {
        if (CanCheck && Utils.AnimationIsFinished(GetComponent<Animator>()))
        {
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
            ThePlayer = aGameObject;
        }
        else
        {
            StartCoroutine(flickeringKeys.Flick());
        }
    }
}
