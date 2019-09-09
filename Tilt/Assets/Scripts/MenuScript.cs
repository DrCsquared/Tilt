using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Click_StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Click_Exit()
    {
        Application.Quit();
    }
}

