using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmovement : MonoBehaviour
{
    [SerializeField]
    private int speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }
    /*
    // Update is called once per frame
    void Update()
    {
        var up_and_down = Input.GetAxis("Vertical");
        var left_and_right = Input.GetAxis("Horizontal");

        this.transform.Translate(left_and_right * speed * Time.deltaTime, up_and_down * speed * Time.deltaTime, 0f);
    }
    */

}
