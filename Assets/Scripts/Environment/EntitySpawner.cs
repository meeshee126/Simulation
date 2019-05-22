using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject m_entity;

    [SerializeField]
    int m_entitys;

    [SerializeField]
    Vector3 m_size;

    void Start()
    {
        for (int i = 0; i < m_entitys; i++)
        {
            Vector3 spawnPosition = this.transform.position + new Vector3(Random.Range(-m_size.x / 2, m_size.x / 2),
                                                                          Random.Range(-m_size.y / 2, m_size.y / 2),
                                                                          Random.Range(-m_size.z / 2, m_size.z / 2));

            Instantiate(m_entity, spawnPosition, Quaternion.identity);
        }
    }
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(this.transform.position, m_size);
    }
}
