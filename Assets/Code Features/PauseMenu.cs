using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void quit()
    {
        Application.Quit();
        Time.timeScale = 1f;
    }

    public void resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
