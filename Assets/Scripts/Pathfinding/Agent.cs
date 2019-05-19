using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    Camera m_camera;

    NavMeshAgent m_agent;

    Rigidbody m_rb;

    float m_timer;

    void Start()
    {
        m_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        m_agent = this.gameObject.GetComponent<NavMeshAgent>();
        m_rb = GetComponent<Rigidbody>();
        m_timer = 0f;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (GetClickedGameobject().name == "YellowSpawner" ||
                GetClickedGameobject().name == "BlueSpawner" ||
                GetClickedGameobject().name == "RedSpawner")
                return;


            Vector3 clickedPosition = GetClickedPosition();
            if (clickedPosition == Vector3.zero)
            {
                return;
            }
            Debug.Log(clickedPosition);

            m_agent.SetDestination(clickedPosition);
        }

        if(Input.GetMouseButtonDown(1) && GetClickedGameobject() == this.gameObject)
        {
            DestroyAgent();
        }
    }

    void DestroyAgent()
    {
        Destroy(this.gameObject);
        Spawner.m_agentCount--;
        Debug.Log(Spawner.m_agentCount);
    }

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
