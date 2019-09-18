
using UnityEngine;

public class IdleState : IState
{
    private PlayerController Parent; //!< Controller of the parent.

    /**
     * Inits the state.
     * @param PlayerController: controller to be used in the state.
     */
    public void Init(PlayerController aParent)
    {
        Parent = aParent;
    }

    /**
     * Function that is called once the state is changed to be the current.
     */
    public void OnEnterState()
    {
    }

    /**
     * Function that is called while the state is the current.
     */
    public void UpdateState()
    {
        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            Parent.GetFSM().ChangeState(Parent.GetState("Walk"), true);
        }
    }

    /**
     * Function that is called once the current state changes.
     */
    public void OnExitState()
    {
    }
}
