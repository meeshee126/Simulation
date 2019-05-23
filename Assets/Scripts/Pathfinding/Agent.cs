using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    private Camera m_camera;

    private NavMeshAgent m_agent;

    void Start()
    {
        m_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        m_agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {   
            // when clicked on spawner or no gameObject, don't move to this position
            if (GetClickedGameobject() == null ||
                GetClickedGameobject().name == "YellowSpawner" ||
                GetClickedGameobject().name == "BlueSpawner" ||
                GetClickedGameobject().name == "RedSpawner")
                return;

            // check if clicked on empty space, don't move to this position
            if (GetClickedPosition() == Vector3.zero)        
                return;
            
            // move agent to clicked position
            m_agent.SetDestination(GetClickedPosition());
        }

        // if right mouse click on agent, destroy it
        if(Input.GetMouseButton(1) && GetClickedGameobject() == this.gameObject)
        {
            DestroyAgent();
        }
    }

    void DestroyAgent()
    {
        Destroy(this.gameObject);
        AgentSpawner.m_agentCount--;
    }

    /// <summary>
    /// function for get clicked mouse position
    /// </summary>
    /// <returns></returns>
    Vector3 GetClickedPosition()
    {
        RaycastHit hit;

        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return Vector3.zero;
    }

    /// <summary>
    /// function for get clicked gameObject
    /// </summary>
    /// <returns></returns>
    GameObject GetClickedGameobject()
    {
        RaycastHit hit;

        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
