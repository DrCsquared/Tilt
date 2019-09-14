using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public void Click_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Click_Exit()
    {
        Application.Quit();
    }
}

