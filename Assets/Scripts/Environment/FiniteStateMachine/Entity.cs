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

    // Start is called before the first frame update
    void Start()
    {
        m_observationTarget = GameObject.Find("Player");

        m_rend = GetComponent<Renderer>();

        m_brain.AddState(new Wander(this));
        m_brain.AddState(new Evade(this));
        m_brain.AddState(new Chase(this));

    }

    // Update is called once per frame
    void Update()
    {
        m_brain.Update();

        float distance = GetDistanceToTarget();



        if(distance <= 2 && Input.GetMouseButtonDown(0))
        {
            SwitchState();
        }
        
    }

    float GetDistanceToTarget()
    {
        return Vector3.Distance(this.gameObject.transform.position, m_observationTarget.gameObject.transform.position);
    }

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
