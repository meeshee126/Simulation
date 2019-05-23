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
        // change Entity material
        m_entity.m_rend.sharedMaterial = m_entity.m_stateMaterial[1];

        // Entity looks to the direction of player
        this.m_gameObject.transform.LookAt(this.m_entity.m_observationTarget.transform.position);

        // entity moves in direction he looks
        this.m_gameObject.transform.position += this.m_gameObject.transform.forward * this.m_entity.m_speed * Time.deltaTime;
    }

    public bool Condition()
    {
        // call this state when entity is in radius from player and not evading   

        if (!this.m_entity.m_observationTarget || !m_entity.m_chase)
        {
            return false;
        }

        return true;
    }
}
