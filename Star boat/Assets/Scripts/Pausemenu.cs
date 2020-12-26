using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    public GameObject StartCanvas;
    public GameObject PauseCanvas;
    public GameObject Player;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Player)
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
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void Exit()
    {
        //      StartCanvas.SetActive(true);
        //  PauseCanvas.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }








    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    
    public void Exit()
    {
   //      StartCanvas.SetActive(true);
   //  PauseCanvas.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    */
}
