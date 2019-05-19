using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Camera m_camera;

    public static bool m_maxAgents;

    public static int m_agentCount;

    public GameObject m_agent;

    public Vector3 m_size;

    private void Start()
    {
        m_agentCount = 0;
        m_camera = GameObject.Find("Main Camera").GetComponent<Camera>(); 
    }

    void Update()
    {
        if (m_maxAgents)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject clickedObject = GetClickedSpawner();

            if(clickedObject.name == this.gameObject.name)
            {
                SpawnEnemy();
                m_agentCount++;
                Debug.Log(m_agentCount);
            }
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = this.transform.position + new Vector3(Random.Range(-m_size.x / 2, m_size.x / 2),
                                                                      Random.Range(-m_size.y / 2, m_size.y / 2),
                                                                      Random.Range(-m_size.z / 2, m_size.z / 2));

        Instantiate(m_agent, spawnPosition, Quaternion.identity);
    }

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
