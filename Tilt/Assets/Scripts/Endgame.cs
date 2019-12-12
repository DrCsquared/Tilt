using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{
    [SerializeField]
    private GameObject score;

    [SerializeField]
    private GameObject win;

    [SerializeField]
    private GameObject lose;

    [SerializeField]
    private GameObject paused;

    [SerializeField]
    private GameObject pause;

    [SerializeField]
    private Rigidbody playerRb;

    [SerializeField]
    private LevelMovement level;

    [SerializeField]
    private Text timeScore;

    private float time;
    private float toRound;

    private bool isPaused;

    private void Start()
    {
        time = 0.0f;

    }

    private void FixedUpdate()
    {

        if (!isPaused)
        {
            toRound = Mathf.Round(time * 1000.0f) / 1000.0f;
            timeScore.text = "Time: " + toRound.ToString();//string.Format("{0}:{1:00}.{2:000}", ((int) time / 60), ((int) time % 60), ((int)time % 1000));
            time += Time.deltaTime;
            
        }
        

    }


    public void Click_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Click_Exit()
    {
        Application.Quit();
    }

    public void Click_Pause()
    {
        isPaused = true;
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
        level.paused = true;
        pause.SetActive(false);
        paused.SetActive(true);
    }

    public void Click_Resume()
    {
        isPaused = true;
        paused.SetActive(false);
        pause.SetActive(true);
        playerRb.constraints = RigidbodyConstraints.None;
        level.paused = false;
    }

    public void Click_Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinCanvas()
    {
        isPaused = true;
        score.SetActive(false);
        win.SetActive(true);
        win.GetComponentInChildren<Text>().text = score.GetComponentInChildren<Text>().text;

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            if (time < PlayerPrefs.GetFloat("Level 1", 0))
            {
                PlayerPrefs.SetFloat("Level 1", time);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            if (time < PlayerPrefs.GetFloat("Level 2", 0))
            {
                PlayerPrefs.SetFloat("Level 2", time);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (time < PlayerPrefs.GetFloat("Level 3", 0))
            {
                PlayerPrefs.SetFloat("Level 3", time);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            if (time < PlayerPrefs.GetFloat("Level 4", 0))
            {
                PlayerPrefs.SetFloat("Level 4", time);
            }
        }
    }

    public void LoseCanvas()
    {
        lose.SetActive(true);        
        score.SetActive(false);
    }
}
