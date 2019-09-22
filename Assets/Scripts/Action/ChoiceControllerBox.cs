using UnityEngine;

public class ChoiceControllerBox : MonoBehaviour
{
    public BoxSwitchManager boxSwitchScript;

    public void PerformAction()
    {
        boxSwitchScript.InitializePositions();
        GetComponent<BoxCollider2D>().enabled = true;
        transform.position = new Vector2(transform.position.x, -0.57f);
    }
}
