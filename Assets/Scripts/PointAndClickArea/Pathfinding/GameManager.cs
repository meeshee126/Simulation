using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public Camera m_camera;
    public GameObject m_player;
    public NavMeshAgent m_Agent;

    void Start()
    {
        m_Agent = m_player.GetComponent<NavMeshAgent>();
       
    }

    void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickedPosition = GetClickedPosition();
            if (clickedPosition == Vector3.zero)
            {
                return;
            }
            Debug.Log(clickedPosition);

            m_Agent.SetDestination(clickedPosition);
        }

       
        
    }

    Vector3 GetClickedPosition()
    {
        RaycastHit hit;

        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}


