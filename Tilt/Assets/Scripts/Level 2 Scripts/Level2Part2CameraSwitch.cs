using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Level2Part2CameraSwitch : MonoBehaviour
{

    [SerializeField]
    private List<CinemachineVirtualCamera> Cameras;

    [SerializeField]
    private GameObject tunnel;

    [SerializeField]
    private GameObject boarder2;



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<BoxCollider>().enabled = false;

            tunnel.SetActive(false);
            boarder2.SetActive(true);
            Cameras[0].enabled = false;
            Cameras[1].enabled = true;

        }
    }
}
