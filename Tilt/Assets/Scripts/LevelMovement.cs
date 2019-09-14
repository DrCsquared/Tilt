using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    private Quaternion localRotation;

    [SerializeField]
    private float speed = 1.0f; // ajustable speed from Inspector in Unity editor

    void Start()
    {
        // copy the rotation of the object itself into a buffer
        localRotation = transform.rotation;
    }


    void Update() // runs 60 fps or so
    {
        // find speed based on delta
        float curSpeed = Time.deltaTime * speed;
        // first update the current rotation angles with input from acceleration axis
        localRotation.y += Input.acceleration.x * curSpeed;
        localRotation.x += Input.acceleration.y * curSpeed;

        // then rotate this object accordingly to the new angle
        this.transform.rotation = localRotation;

    }

}

