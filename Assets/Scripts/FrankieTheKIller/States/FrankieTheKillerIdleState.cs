using UnityEngine;

public class FrankieTheKillerIdleState : CState
{
    private ViewFinderController MyFrankieController;

    public override void Init(BaseController aParent)
    {
        base.Init(aParent);
        MyFrankieController = (ViewFinderController)Controller;
    }

    /**
     * Function that is called while the state is the current.
     */
    public override void UpdateState()
    {
        MyFrankieController.CircleMovement();
    }
}
