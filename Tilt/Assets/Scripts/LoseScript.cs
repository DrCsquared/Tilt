using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseScript : MonoBehaviour
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
