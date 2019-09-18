using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    private List<IState> StatesStack;   //!< Stack of states. The current state is always the one in the top.
    private IState CurrentState;        //!< The current state of the FSM. The one that is going to be updated.
    private bool IsChangingState;       //!< Indicates if the fsm is changing state or not.

    /**
     * Starts the FSM with all the needed Data.
     */
    public void StartFSM()
    {
        CurrentState = null;
        StatesStack = new List<IState>();
        IsChangingState = false;
    }

    /**
     * Update is called once per frame
     */
    void FixedUpdate()
    {
        if (!IsChangingState && CurrentState != null)
        {
            CurrentState.UpdateState();
        }
    }

    /**
     * Changes the state.
     * @param aState: new state that will be added to the stack.
     * @param aPushStack: true if it has to be pushed, false if it has to replace the state at the top.
     */
    public void ChangeState(IState aState, bool aPushStack = false)
    {
        if (StatesStack != null)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExitState();
            }

            CurrentState = aState;
            CurrentState.OnEnterState();

            IsChangingState = true;

            if (!aPushStack && StatesStack.Contains(CurrentState))
            {
                StatesStack.Remove(CurrentState);
            }

            if (!StatesStack.Contains(aState))
            {
                StatesStack.Add(aState);
            }

            IsChangingState = false;
        }
    }
}
