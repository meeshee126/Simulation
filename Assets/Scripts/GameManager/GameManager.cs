using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text m_uiAgentCounter;

    [SerializeField]
    GameObject m_uiPauseMenu, m_rain;

    [SerializeField]
    ParticleSystem m_rainFall, m_rainExplosion, m_rainMist;

    void Start()
    {
        // Check between scenes if we need mouse cursor
        CursorLock();
    }

    void Update()
    {
        // when pathinfing scene is active, call AgentCounter function
        if (SceneManager.GetActiveScene().name == "Pathfinding")
        {
            AgentCounter();
        }

        // toggle rains in environment scene
        if (SceneManager.GetActiveScene().name == "Environment" && Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleRain();
        }

        InGameMenu();
    }

    void CursorLock()
    {
        // deactivate mouse lockstate and visible 
        if (SceneManager.GetActiveScene().name == "Pathfinding")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // activate mouse lockstate and visible 
        else if (SceneManager.GetActiveScene().name == "Environment")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    /// <summary>
    /// function for counting agents
    /// </summary>
    void AgentCounter()
    {
        m_uiAgentCounter.text = AgentSpawner.m_agentCount.ToString();

        if (AgentSpawner.m_agentCount == 100)
        {
            AgentSpawner.m_maxAgents = true;
        }

        else
        {
            AgentSpawner.m_maxAgents = false;
        }
    }

    void ToggleRain()
    {
        // deactivating rain 
        if(m_rain.activeInHierarchy)
        {
            m_rain.gameObject.SetActive(false);
            m_rainFall.Stop();
            m_rainExplosion.Stop();
            m_rainMist.Stop();
        }

        // activating rain
        else
        {
            m_rain.gameObject.SetActive(true);
            m_rainFall.Play();
            m_rainExplosion.Play();
            m_rainMist.Play();
        }
    }

    void InGameMenu()
    {
        // restarts simulation
        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name == "Pathfinding")
        {
            SceneManager.LoadScene("Pathfinding");
        }

        // open or close pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        // checks after pressing "escape" button if pause Menu is active or not

        // if pause Menu is not active
        if (m_uiPauseMenu.activeInHierarchy == false)
        {
            if (SceneManager.GetActiveScene().name == "Environment")
            {
                // deactivate camera look 
                GameObject.Find("Main Camera").GetComponent<CameraMouseLook>().enabled = false;

                // enable mouse
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            // pause Menu is setting active
            m_uiPauseMenu.gameObject.SetActive(true);

            // disable enviroment physics
            Time.timeScale = 0;
        }

        // if pause menu is active after pressing "escape" button
        else
        {
            if (SceneManager.GetActiveScene().name == "Environment")
            {
                // activate mouse look
                GameObject.Find("Main Camera").GetComponent<CameraMouseLook>().enabled = true;

                // disable mouse
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            // pause menu is setting inactive
            m_uiPauseMenu.gameObject.SetActive(false);

            // enable enviroment physics
            Time.timeScale = 1;
        }
    }

    public void ButtonStartGame()
    {
        SceneManager.LoadScene("Environment");
    }

    public void ButtonResumeGame()
    {
        PauseGame();
    }

    public void ButtonBackToSimulation()
    {
        // pause menu is setting inactive
        m_uiPauseMenu.gameObject.SetActive(false);

        // enable enviroment physics
        Time.timeScale = 1;

        SceneManager.LoadScene("Environment");
    }

    public void ButtonQuitGame()
    {
        Application.Quit();
    }
}
