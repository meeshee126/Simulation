using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text m_uiAgentCounter;

    
    public GameObject m_uiPauseMenu;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Pathfinding")
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (SceneManager.GetActiveScene().name == "Environment")
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Pathfinding")
        {
            AgentCounter();
        }

        InGameMenu();
    }

    void AgentCounter()
    {
        m_uiAgentCounter.text = Spawner.m_agentCount.ToString();

        if (Spawner.m_agentCount == 100)
        {
            Spawner.m_maxAgents = true;
        }
        else
        {
            Spawner.m_maxAgents = false;
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
                GameObject.Find("Main Camera").GetComponent<CameraMouseLook>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
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
                GameObject.Find("Main Camera").GetComponent<CameraMouseLook>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
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
