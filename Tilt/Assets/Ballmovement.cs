using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmovement : MonoBehaviour
{
    [SerializeField]
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var up_and_down = Input.GetAxis("Vertical");
        var left_and_right = Input.GetAxis("Horizontal");

        this.transform.Translate(left_and_right * speed * Time.deltaTime, 0f , up_and_down * speed * Time.deltaTime);
    }
}
