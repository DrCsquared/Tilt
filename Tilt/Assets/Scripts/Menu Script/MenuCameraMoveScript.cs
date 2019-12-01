using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MenuCameraMoveScript : MonoBehaviour
{
    //[SerializeField]
    //private List<CinemachineVirtualCamera> Cameras;

    [SerializeField]
    private GameObject MainMenuCamera;

    [SerializeField]
    private GameObject LevelSelectionCamera;

    [SerializeField]
    private GameObject HighScoresCamera;

    [SerializeField]
    private GameObject PlayerSelectionCamera;

    private GameObject ActiveCamera;

    private void Start()
    {
        MainMenuCamera.SetActive(true);
        PlayerSelectionCamera.SetActive(false);
        HighScoresCamera.SetActive(false);
        LevelSelectionCamera.SetActive(false);
        ActiveCamera = MainMenuCamera;
    }


    //public void cameraMoveToLevelSide()
    //{
    //    Cameras[0].enabled = false;
    //    Cameras[1].enabled = true;
    //    ActiveCamera = Cameras[1];
    //}

    //public void cameraBack()
    //{
    //    ActiveCamera.enabled = false;
    //    Cameras[0].enabled = true;
    //    ActiveCamera = Cameras[0];
    //}

    //public void cameraMoveToPlayerSelectSide()
    //{
    //    Cameras[0].enabled = false;
    //    Cameras[3].enabled = true;
    //    ActiveCamera = Cameras[3];
    //}
    //public void cameraMoveToHighScoreSide()
    //{
    //    Cameras[0].enabled = false;
    //    Cameras[2].enabled = true;
    //    ActiveCamera = Cameras[2];
    //}


    public void cameraMoveToLevelSide()
    {
        MainMenuCamera.SetActive(false);
        PlayerSelectionCamera.SetActive(false);
        HighScoresCamera.SetActive(false);
        LevelSelectionCamera.SetActive(true);
        ActiveCamera = LevelSelectionCamera;
    }

    public void cameraBack()
    {
        ActiveCamera.SetActive(false);
        MainMenuCamera.SetActive(true);
        ActiveCamera = MainMenuCamera;
    }

    public void cameraMoveToPlayerSelectSide()
    {
       
        MainMenuCamera.SetActive(false);
        LevelSelectionCamera.SetActive(false);
        HighScoresCamera.SetActive(false);
        PlayerSelectionCamera.SetActive(true);
        ActiveCamera = PlayerSelectionCamera;
    }
    public void cameraMoveToHighScoreSide()
    {

        MainMenuCamera.SetActive(false);
        LevelSelectionCamera.SetActive(false);
        PlayerSelectionCamera.SetActive(false);
        HighScoresCamera.SetActive(true);
        
        ActiveCamera = HighScoresCamera;
    }

}
