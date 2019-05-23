using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private bool m_toggleDayNight;

    private Vector3 m_startPosition;

    private void Start()
    {
        m_startPosition = transform.position;

        // set start position
        ResetDayNight();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleDayNight();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ResetDayNight();
        }

        DayAndNightCycle(); 
    }

    void DayAndNightCycle()
    {
        if (m_toggleDayNight)
        {
            // rotate object around a certain point
            transform.RotateAround(Vector3.zero, Vector3.right, 10 * Time.deltaTime);
            transform.LookAt(Vector3.zero);           
        }
    }

    /// <summary>
    /// reset position
    /// </summary>
    void ResetDayNight()
    {
        transform.position = m_startPosition;
        transform.LookAt(Vector3.zero);
    }

    /// <summary>
    /// function for toggle Object movement
    /// </summary>
    void ToggleDayNight()
    { 
        if(m_toggleDayNight)
        {
            m_toggleDayNight = false;
        }

        else 
        {
            m_toggleDayNight = true;
        }
    }
}
