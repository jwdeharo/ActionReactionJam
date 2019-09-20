using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    private List<CState> StatesStack;   //!< Stack of states. The current state is always the one in the top.
    private CState CurrentState;        //!< The current state of the FSM. The one that is going to be updated.
    private bool IsChangingState;       //!< Indicates if the fsm is changing state or not.
    [SerializeField]
    private bool IsActive = true;

    /**
     * Starts the FSM with all the needed Data.
     */
    public void StartFSM()
    {
        CurrentState = null;
        StatesStack = new List<CState>();
        IsChangingState = false;
    }

    /**
     * Update is called once per frame
     */
    void FixedUpdate()
    {
        if (IsActive && !IsChangingState && CurrentState != null)
        {
            CurrentState.UpdateState();
        }
    }

    /**
     * Changes the state.
     * @param aState: new state that will be added to the stack.
     * @param aPushStack: true if it has to be pushed, false if it has to replace the state at the top.
     */
    public void ChangeState(CState aState)
    {
        if (IsActive)
        {
            IsChangingState = true;

            if (StatesStack != null && CurrentState != aState)
            {
                ExitState();

                CurrentState = aState;
                CurrentState.OnEnterState();

                if (!StatesStack.Contains(aState))
                {
                    StatesStack.Add(aState);
                }
            }

            IsChangingState = false;
        }
    }

    public void PopState()
    {
        if (IsActive)
        {
            IsChangingState = true;

            ExitState();

            if (StatesStack.Contains(CurrentState))
            {
                StatesStack.Remove(CurrentState);
            }

            CurrentState = StatesStack[StatesStack.Count - 1];
            CurrentState.OnEnterState();

            IsChangingState = false;
        }
    }

    private void ExitState()
    {
        if (IsActive && CurrentState != null)
        {
            CurrentState.OnExitState();
        }
    }

    public void SetActive(bool aIsActive)
    {
        IsActive = aIsActive;
    }
}
