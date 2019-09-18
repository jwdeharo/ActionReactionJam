using System.Collections.Generic;
using UnityEngine;

abstract public class BaseController : MonoBehaviour
{
    protected FSM MyFSM;                              //!< Finite state machine of the player.
    protected Dictionary<string, CState> States; //!< List of states that the player have.

    /**
     * Returns a state from the dictionary of states.
     * @param aStateName: State to return.
     */
    public CState GetState(string aStateName)
    {
        return States[aStateName];
    }

    /**
     * Returns the FSM of the player.
     * @return FSM: FSM of the player.
     */
    public FSM GetFSM()
    {
        return MyFSM;
    }
}
