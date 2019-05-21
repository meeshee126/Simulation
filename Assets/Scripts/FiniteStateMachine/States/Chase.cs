using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : IState
{

    public Entity m_entity;
    public GameObject m_gameObject => this.m_entity.gameObject;

    public Chase(Entity p_entity)
    {
        m_entity = p_entity;
    }

    public void Execute()
    {
        m_entity.m_rend.sharedMaterial = m_entity.m_stateMaterial[1];
        Debug.Log("Chase");
        this.m_gameObject.transform.LookAt(this.m_entity.m_observationTarget.transform.position);
        if (this.GetRadiusToTarget() <= 1f) return;
        this.m_gameObject.transform.position += this.m_gameObject.transform.forward * this.m_entity.m_speed * Time.deltaTime;
    }

    public float GetRadiusToTarget()
    {
        return Vector3.Distance(m_entity.gameObject.transform.position, this.m_entity.m_observationTarget.gameObject.transform.position);
    }

    public bool Condition()
    {
        if(!this.m_entity.m_observationTarget || !m_entity.m_chase)
        {
            return false;
        }
        float distance =  GetRadiusToTarget();

        return true;
    }

}
