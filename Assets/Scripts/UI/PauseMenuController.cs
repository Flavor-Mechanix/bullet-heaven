using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject statsMenu;
    [SerializeField] private string _currentLevel;
    [SerializeField] private string _mainMenu;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseToggle();
        }
    }

    private void PauseToggle()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            statsMenu.SetActive(true);
            statsMenu.GetComponent<StatsPanel>().UpdateStats();
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            statsMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(_currentLevel);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
        Time.timeScale = 1;
    }
}
