abstract public class CState
{
    protected BaseController Controller; //!< Controller of the parent.

    /**
     * Inits the state.
     * @param PlayerController: controller to be used in the state.
     */
    virtual public void Init(BaseController aParent)
    {
        Controller = aParent;
    }

    /**
     * Function that is called once the state is changed to be the current.
     */
    virtual public void OnEnterState()
    {

    }

    /**
     * Function that is called while the state is the current.
     */
    virtual public void UpdateState()
    {

    }

    /**
     * Function that is called once the current state changes.
     */
    virtual public void OnExitState()
    {

    }
}
