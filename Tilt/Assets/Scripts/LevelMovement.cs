using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMovement : MonoBehaviour
{
    private Quaternion localRotation;

    [SerializeField]
    private float speed = 1.0f; // ajustable speed from Inspector in Unity editor

    public bool flipping;

    private float zPos;

    private Quaternion flip;

    private float timer;

    private bool down;

    [SerializeField]
    private Ballmovement ballmovement;

    [SerializeField]
    private Text test;

    void Start()
    {
        // copy the rotation of the object itself into a buffer
        localRotation = transform.rotation;
    }


    void Update() // runs 60 fps or so
    {
        if (flipping)
        {
            timer+= Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, flip, 1f * Time.deltaTime);
            localRotation = transform.rotation;
            if (timer > 3)
            {
                flipping = false;
                timer = 0;
            }
            down = !down;
        }
        else
        {
            // find speed based on delta
            float curSpeed = Time.deltaTime * speed;
            // first update the current rotation angles with input from acceleration axis
            localRotation.z += -Input.acceleration.x * curSpeed;
            localRotation.x += Input.acceleration.y * curSpeed;
            // then rotate this object accordingly to the new angle
            transform.rotation = localRotation;
            test.text = transform.rotation.ToString();
        }

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        ballmovement.done = true;
    }

    public void FlipStage()
    {
        if (!down)
        {
            zPos = transform.rotation.z - 180;
        }
        else if (down)
        {
            zPos = transform.rotation.z - 360;
        }
        flip = Quaternion.Euler(0,0, zPos);
        flipping = true;
        StartCoroutine("wait");
    }

}

