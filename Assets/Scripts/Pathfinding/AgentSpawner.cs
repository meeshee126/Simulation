using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    private Camera m_camera;

    public static bool m_maxAgents;

    public static int m_agentCount;

    [SerializeField]
    GameObject m_agent;

    [SerializeField]
    Vector3 m_size;

    private void Start()
    {
        m_agentCount = 0;
        m_camera = GameObject.Find("Main Camera").GetComponent<Camera>(); 
    }

    void Update()
    {
        // check maximum agents in simulation
        if (m_maxAgents)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            // if not clicked on spawner, return input
            if (GetClickedSpawner() == null)
                return;

            // spawn agents if clicked on spawner
            if(GetClickedSpawner().name == this.gameObject.name)
            {
                SpawnEnemy();

                // count agents
                m_agentCount++;
            }
        }
    }

    void SpawnEnemy()
    {
        // random position on a setted spawn area
        Vector3 spawnPosition = this.transform.position + new Vector3(Random.Range(-m_size.x / 2, m_size.x / 2),
                                                                      Random.Range(-m_size.y / 2, m_size.y / 2),
                                                                      Random.Range(-m_size.z / 2, m_size.z / 2));

        // spawn agent
        Instantiate(m_agent, spawnPosition, Quaternion.identity);
    }

    /// <summary>
    /// function for get clicked spawner
    /// </summary>
    /// <returns></returns>
    GameObject GetClickedSpawner()
    {
        RaycastHit hit;

        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject;
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, m_size);
    }
}
