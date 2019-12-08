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
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
        level.paused = true;
        pause.SetActive(false);
        paused.SetActive(true);
    }

    public void Click_Resume()
    {
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
        score.SetActive(false);
        win.SetActive(true);
    }

    public void LoseCanvas()
    {
        lose.SetActive(true);
        lose.GetComponentInChildren<Text>().text = score.GetComponentInChildren<Text>().text;
        score.SetActive(false);
    }
}
