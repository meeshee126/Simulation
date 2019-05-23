using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Machine
{
    protected List<IState> m_states = new List<IState>();

    /// <summary>
    /// function for adding alle states
    /// </summary>
    /// <param name="p_newState"></param>
    public void AddState(IState p_newState)
    {
        this.m_states.Add(p_newState);
    }

    public void Update()
    {
        // check if List is empty
        if (!this.m_states.Any()) return;

        // check all conditions in eah state
        foreach (IState state in this.m_states)
        {
            if (state.Condition())
            {
                // execute state from condition which is true
                state.Execute();
                break;
            }
        }
    }
}
