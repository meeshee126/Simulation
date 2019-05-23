using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathfinderTrigger : MonoBehaviour
{ 
    [SerializeField]
    GameObject m_uiStartPathfinding;

    private void OnTriggerStay(Collider other)
    {
        // activate ui text

        if (other.gameObject.name == "Player")
        {
            m_uiStartPathfinding.gameObject.SetActive(true);

            // starts pathfinding scene
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Pathfinding");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // deactivate ui text

        if (other.gameObject.name == "Player")
        {
            m_uiStartPathfinding.gameObject.SetActive(false);
        }
    }
}
