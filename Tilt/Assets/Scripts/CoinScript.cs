using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{


    //// Audio tutorial helped me add sound to this project https://www.youtube.com/watch?v=egxNXuwf0_g
    //[SerializeField]
    //private AudioClip coinSound;

    //[SerializeField]
    //private AudioSource coinSource;
    // Start is called before the first frame update
    void Start()
    {
       // coinSource.clip = coinSound;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           // coinSource.Play();
            Destroy(this.gameObject);
        }
    }
}
