using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public GameObject m_target;

    public NavMeshAgent m_agent;

    public bool m_standing;

    public float m_jumpForce;

    public float sdsd;

    Rigidbody m_rb;

    void Start()
    {
        m_agent = this.gameObject.GetComponent<NavMeshAgent>();
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_agent.SetDestination(m_target.transform.position);

        float velocity = m_agent.velocity.magnitude;

        sdsd = velocity;

        if (velocity == 0f)
        {
            m_standing = true;
        }

        if (m_standing && velocity >= 0.1f)
        {
            Debug.Log("sdas");
            transform.position = Vector3.up * m_jumpForce;
            m_standing = false;
        }
        

    }
}
