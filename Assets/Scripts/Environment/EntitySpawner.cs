using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject m_entity;

    [SerializeField]
    int m_entityAmount;

    [SerializeField]
    Vector3 m_size;

    void Start()
    {
        // spawns a certain number of enitys
        for (int i = 0; i < m_entityAmount; i++)
        {
            // random position on a setted spawn area
            Vector3 spawnPosition = this.transform.position + new Vector3(Random.Range(-m_size.x / 2, m_size.x / 2),
                                                                          Random.Range(-m_size.y / 2, m_size.y / 2),
                                                                          Random.Range(-m_size.z / 2, m_size.z / 2));
            // spawn entity
            Instantiate(m_entity, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(this.transform.position, m_size);
    }
}
