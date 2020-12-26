using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreTextElement;

    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button ExitButton, ExitButton1;
    public GameObject[] canvasRecord;
    public GameObject Player;
    public Text Record1;
    public Text Record2;


    public GameObject menu;
    

    private bool isStarted = false;
    private int score = 0;

    public bool getIsStarted()
    {
        return isStarted;
    }
    // Start is called before the first frame update
    void Start()
    {
        //таблица рекордов
        scoreTextElement.text = "Score: 0";      

        if
            (PlayerPrefs.GetInt("Record1") < score)
            PlayerPrefs.SetInt("Record1", score);
        Record1.text = "<size=40>РЕКОРД:</size>" + PlayerPrefs.GetInt("Record1") + "\n<size=40>СЧЁТ:</size>" + score;
        startButton.onClick.AddListener(delegate
        {
            
            menu.SetActive(false);
            isStarted = true;

           /* if (isStarted = true)
            {
                isStarted = f
                isStarted = true;
            }
            else
            {
                isStarted = true;
            }*/
        });
        ExitButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });
        ExitButton1.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        });

    }
    //очки
    public void increaseScore(int increment)
    {
        
        score += increment;
        scoreTextElement.text = "Счёт: " + score;

        



        // Record1.text = Time.timeScale.ToString() + " " + score.ToString();


    }
    

}
