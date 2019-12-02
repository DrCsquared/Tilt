using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MenuCameraMoveScript : MonoBehaviour
{
    [SerializeField]
    private List<CinemachineVirtualCamera> Cameras;

    [SerializeField]
    private Canvas playerPreviewCanvas;

    private CinemachineVirtualCamera ActiveCamera;

    [SerializeField]
    private GameObject playerPreviewButton;

    private void Start()
    {

        for(int i = 1; i < Cameras.Count; i++)
        {
            Cameras[i].enabled = false;
        }
        playerPreviewCanvas.enabled = false;
        Cameras[0].enabled = true;
        
        
        ActiveCamera = Cameras[0];
    }


    public void cameraMoveToLevelSide()
    {
        Cameras[0].enabled = false;
        Cameras[1].enabled = true;
        ActiveCamera = Cameras[1];
    }

    public void cameraBack()
    {
        ActiveCamera.enabled = false;
        Cameras[0].enabled = true;
        playerPreviewCanvas.enabled = false;
        ActiveCamera = Cameras[0];
    }

    public void cameraMoveToPlayerSelectSide()
    {
        playerPreviewCanvas.enabled = false;
        if (Cameras[4].enabled == true)
        {
            playerPreviewButton.SetActive(false);
            Cameras[4].enabled = false;
        }
        if (Cameras[0].enabled == true)
        {
            Cameras[0].enabled = false;
        }
        Cameras[3].enabled = true;
        ActiveCamera = Cameras[3];
    }
    public void cameraMoveToHighScoreSide()
    {
        Cameras[0].enabled = false;
        Cameras[2].enabled = true;
        ActiveCamera = Cameras[2];
    }

    public void cameraMoveToPlayerPreviewSide()
    {
        Cameras[0].enabled = false;
        Cameras[4].enabled = true;
        ActiveCamera = Cameras[4];

        StartCoroutine(Wait(2.5f));
    }

    private IEnumerator Wait(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            playerPreviewCanvas.enabled = true;

            
       
    }
}
