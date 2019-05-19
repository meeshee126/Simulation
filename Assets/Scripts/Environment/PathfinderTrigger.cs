using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathfinderTrigger : MonoBehaviour
{ 
    public GameObject m_uiStartPathfinding;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            m_uiStartPathfinding.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Pathfinding");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            m_uiStartPathfinding.gameObject.SetActive(false);
        }
    }

}
