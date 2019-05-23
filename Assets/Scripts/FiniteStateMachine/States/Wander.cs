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
        // change Entity material
        m_entity.m_rend.sharedMaterial = m_entity.m_stateMaterial[0];

        this.AssignRandomRotation();

        // entity moves in direction he looks
        m_entity.transform.position += this.m_gameObject.transform.forward * this.m_entity.m_speed * Time.deltaTime;
    }

    protected void AssignRandomRotation()
    {
        // random change rotation
        Vector3 rotation = new Vector3 (0, Random.Range(-10f, 10f), 0f);
        this.m_gameObject.transform.Rotate(rotation);
    }

    public bool Condition()
    {
        float distance = m_entity.GetDistanceToTarget();

        // call this state when entity is not in radius from player
        return distance > this.m_entity.m_observationRadius;
    }
}
