/**
* Interface of a state. 
*/
public interface IState
{

    /**
     * Inits the state.
     * @param PlayerController: controller to be used in the state.
     */
    void Init(PlayerController aParent);
    /**
     * Function that is called once the state is changed to be the current.
     */
    void OnEnterState();

    /**
     * Function that is called while the state is the current.
     */
    void UpdateState();

    /**
     * Function that is called once the current state changes.
     */
    void OnExitState();
}
