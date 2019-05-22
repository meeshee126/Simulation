using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Machine
{
    protected List<IState> m_states = new List<IState>();

    public void Update()
    {
        if (!this.m_states.Any()) return;

        Debug.Log("Brain is Updating...");

        foreach (IState state in this.m_states)
        {
            if(state.Condition())
            {
                state.Execute();
                break;
            }
        }

       //ToDO: Chech for more than one state
       // m_states.First().Execute();
    }
    public void AddState(IState p_newState)
    {
        this.m_states.Add(p_newState);
    }
}
