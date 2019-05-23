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
        // change Entity material
        m_entity.m_rend.sharedMaterial = m_entity.m_stateMaterial[2];

        // entity looks at the opposite direction of the player
        this.m_gameObject.transform.LookAt(2 * this.m_gameObject.transform.position - this.m_entity.m_observationTarget.transform.position);

        // entity moves in direction he looks
        this.m_gameObject.transform.position += this.m_gameObject.transform.forward.normalized * this.m_entity.m_speed * Time.deltaTime;
    }

    public bool Condition()
    {
        // call this state when entity is in radius from player and not chasing    
        
        if (!this.m_entity.m_observationTarget  || m_entity.m_chase)
        {
            return false;
        }

        return true;
    }
}

