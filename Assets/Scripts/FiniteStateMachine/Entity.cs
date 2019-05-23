using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Range(1f, 100f)]
    public float m_speed = 20f;

    [Range(1f, 30f)]
    public float m_observationRadius = 7.5f;

    public bool m_chase = true;

    public Material[] m_stateMaterial;

    public Renderer m_rend;

    public GameObject m_observationTarget;

    public Machine m_brain = new Machine();

    void Start()
    {
        m_observationTarget = GameObject.Find("Player");

        m_rend = GetComponent<Renderer>();

        // adding states 
        m_brain.AddState(new Wander(this));
        m_brain.AddState(new Evade(this));
        m_brain.AddState(new Chase(this));
    }

    void Update()
    {
        m_brain.Update();

        float distance = GetDistanceToTarget();

        // switching state between chase and evade by mouse click
        if(distance <= 2 && Input.GetMouseButtonDown(0))
        {
            SwitchState();
        }
    }

    public float GetDistanceToTarget()
    {
        // get distance from entity and player
        return Vector3.Distance(this.gameObject.transform.position, m_observationTarget.gameObject.transform.position);
    }

    /// <summary>
    /// function for switching states between chase and evade
    /// </summary>
    void SwitchState()
    {
        if (m_chase)
        {
            m_chase = false;
        }

        else if(!m_chase)
        {
            m_chase = true;
        }
    }
}
