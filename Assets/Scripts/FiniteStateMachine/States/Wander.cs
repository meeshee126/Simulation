using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : IState
{

    public Entity m_entity;
    public GameObject m_gameObject => this.m_entity.gameObject;

    public NavMeshAgent m_nacAgent;

    public Wander(Entity p_entity)
    {
        m_entity = p_entity;
    }

    public void Execute()
    {
        m_entity.m_rend.sharedMaterial = m_entity.m_stateMaterial[0];
        Debug.Log("Wander");
        this.AssignRandomRotation();
        m_entity.transform.position += this.m_gameObject.transform.forward * this.m_entity.m_speed * Time.deltaTime;
    }

    protected void AssignRandomRotation()
    {
        Vector3 rotation = new Vector3 (0, Random.Range(-10f, 10f), 0f);
        this.m_gameObject.transform.Rotate(rotation);
    }

    public float GetRadiusToTarget()
    {
        return Vector3.Distance(m_entity.gameObject.transform.position, this.m_entity.m_observationTarget.gameObject.transform.position);
    }

    public bool Condition()
    {
        float distance = GetRadiusToTarget();

        return distance > this.m_entity.m_observationRadius;
    }
}
