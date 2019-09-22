using UnityEngine;

public class ChoiceControllerBoxDown : ChoiceGeneral
{
    [SerializeField]
    private GameObject BoxDown = null;

    protected override void PerformAction()
    {
        BoxDown.GetComponent<BoxCollider2D>().enabled = true;
        BoxDown.transform.position = new Vector2(BoxDown.transform.position.x, -0.57f);
        if (MustDestroy)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
