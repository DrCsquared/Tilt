using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TunnelCameraSwitch : MonoBehaviour
{

    [SerializeField]
    private List<CinemachineVirtualCamera> Cameras;


    [SerializeField]
    private GameObject Level2;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<BoxCollider>().enabled = false;

            
            Level2.SetActive(true);


            Cameras[0].enabled = false;
            Cameras[1].enabled = true;

        }
    }
}
