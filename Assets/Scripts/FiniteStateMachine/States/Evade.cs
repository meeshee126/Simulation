using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : IState
{

    public Entity m_entity;
    public GameObject m_gameObject => this.m_entity.gameObject;

    public Evade(Entity p_entity)
    {
        m_entity = p_entity;
    }

    public void Execute()
    {
        m_entity.m_rend.sharedMaterial = m_entity.m_stateMaterial[2];
        Debug.Log("Evade");
        this.m_gameObject.transform.LookAt(2 * this.m_gameObject.transform.position - this.m_entity.m_observationTarget.transform.position);
        Vector3 forwardVector = this.m_entity.transform.position - this.m_entity.m_observationTarget.transform.position;
        this.m_gameObject.transform.position += this.m_gameObject.transform.forward.normalized * this.m_entity.m_speed * Time.deltaTime;
    }

    public float GetRadiusToTarget()
    {
        return Vector3.Distance(m_entity.gameObject.transform.position, this.m_entity.m_observationTarget.gameObject.transform.position);
    }

    public bool Condition()
    {
        if (!this.m_entity.m_observationTarget  || m_entity.m_chase)
        {
            return false;
        }

        float distance = GetRadiusToTarget();

        return true;
    }
}

