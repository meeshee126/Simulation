using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateTrigger : MonoBehaviour
{
    private Text m_uiStateText;

    private void Start()
    {
        m_uiStateText = GameObject.Find("TextSwitchState").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // activate ui text
        if (other.gameObject.name == "Player")
        {
            m_uiStateText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // deactivate ui text
        if (other.gameObject.name == "Player")
        {
            m_uiStateText.enabled = false ;
        }
    }
}
