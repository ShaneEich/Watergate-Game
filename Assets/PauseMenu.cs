using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false; //Check if game is currently paused or not
    Scene ActiveScene;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
           if (GameIsPaused)
            {
                Resume();

            } 
           else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        ActiveScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(ActiveScene.name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
