using UnityEngine;

public class ChoiceControllerBox : MonoBehaviour
{
    public GameObject box;

    public void PerformAction()
    {
        box.GetComponent<BoxCollider2D>().enabled = true;
        box.transform.position = new Vector2(box.transform.position.x, -0.57f);
    }
}
