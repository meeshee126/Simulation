using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingManager : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        AgentCounter();
    }

    void AgentCounter()
    {
        if (Spawner.m_agentCount == 20)
        {
            Spawner.m_maxAgents = true;
        }
        else
        {
            Spawner.m_maxAgents = false;
        }
    }
}
