using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{

    [SerializeField]
    private List<CinemachineVirtualCamera> Cameras;
    // Start is called before the first frame update
    void Start()
    {
        
        Cameras[0].enabled = true;
        Cameras[1].enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<BoxCollider>().enabled = false;

            Cameras[0].enabled = false;
            Cameras[1].enabled = true;
            
        }
    }
}
