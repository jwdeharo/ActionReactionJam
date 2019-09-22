using UnityEngine;

public class ChoiceControllerThrowBox : ChoiceGeneral
{
    [SerializeField]
    private Transform Target = null;
    [SerializeField]
    private PlayerController ThePlayerController = null;
    [SerializeField]
    private MovableObjectsController TheBoxMovableController = null;

    protected override void PerformAction()
    {
        TheBoxMovableController.SetThrowing(true);
        if (MustDestroy)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
