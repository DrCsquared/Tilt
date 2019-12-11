using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{

    [SerializeField]
    private List<CinemachineVirtualCamera> Cameras;

    [SerializeField]
    private GameObject middle;

    [SerializeField]
    private GameObject Tunnel;

    [SerializeField]
    private Ballmovement ballScript;

    [SerializeField]
    private GameObject Level1;

    // Start is called before the first frame update
    void Start()
    {
        
        Cameras[0].enabled = true;
        Cameras[1].enabled = false;
        Cameras[2].enabled = false;
        

    }

    // Update is called once per frame
    void Update()
    {

        if (ballScript.score == 10)
        {
            middle.SetActive(false);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<BoxCollider>().enabled = false;

            Tunnel.SetActive(true);
            Level1.SetActive(false);


            Cameras[0].enabled = false;
            Cameras[1].enabled = true;
            
        }
    }
}
