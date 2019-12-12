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
    private GameObject Level;

    [SerializeField]
    private Ballmovement ballmovement;

    [SerializeField]
    private GameObject player;

    public bool paused;

    public bool frozen;

    private float ballSpeed = 8.0f;
    private bool drag = false;

    private Vector3 pointA;
    private Vector3 pointB;
    [SerializeField]
    private GameObject joy;
    [SerializeField]
    private GameObject threshold;
    private Vector3 init;
    private Vector3 current;
    private Vector3 clamp;

    void Start()
    {
        // copy the rotation of the object itself into a buffer
        localRotation = transform.rotation;
        joy.SetActive(false);
        threshold.SetActive(false);
    }


    void Update() // runs 60 fps or so
    {        
        if (!paused)
        {
            if (flipping)
            {
                timer+= Time.deltaTime;
                Level.transform.rotation = Quaternion.Lerp(Level.transform.rotation, flip, 1f * Time.deltaTime);
                localRotation = transform.rotation;
                if (timer > 3)
                {
                    flipping = false;
                    timer = 0;
                }
                down = !down;
            }
            else if (!frozen)
            {
                if (joy.activeInHierarchy || threshold.activeInHierarchy)
                {
                    drag = false;
                    joy.SetActive(false);
                    threshold.SetActive(false);
                }
                // find speed based on delta
                float curSpeed = Time.deltaTime * speed;
                // first update the current rotation angles with input from acceleration axis
                localRotation.z += -Input.acceleration.x * curSpeed;
                localRotation.x += Input.acceleration.y * curSpeed;
                // then rotate this object accordingly to the new angle
                transform.rotation = localRotation;
            }
            else if (frozen)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pointA = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
                    init = Input.mousePosition;
                    if (Input.mousePosition.y <= 400)
                    {
                        joy.transform.position = init;
                        threshold.transform.position = init;
                        joy.SetActive(true);
                        threshold.SetActive(true);
                    }
                }
                if (Input.GetMouseButton(0))
                {
                    drag = true;
                    pointB = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
                    current = Input.mousePosition;
                    clamp = Vector3.ClampMagnitude((current - init), 70);
                    joy.transform.position = new Vector3(init.x + clamp.x, init.y + clamp.y);

                }
                else
                {
                    drag = false;
                    joy.SetActive(false);
                    threshold.SetActive(false);    
                }

                if (drag)
                {
                    Vector3 offset = pointB - pointA;
                    Vector3 direction = Vector3.ClampMagnitude(offset, 1);                  
                    Move(direction);
                }
            }
        }
    }

    void Move(Vector3 dir)
    {
        if (player != null)
        {
            player.GetComponent<Rigidbody>().AddForce(dir * ballSpeed);
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
            zPos = Level.transform.rotation.z - 180;
        }
        else if (down)
        {
            zPos = Level.transform.rotation.z - 360;
        }
        flip = Quaternion.Euler(0,0, zPos);
        flipping = true;
        StartCoroutine("wait");
        
    }

}

