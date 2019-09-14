using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Colin Cumberland
 * Applications and Scripting CGDD 3103
 * PhD D. Michael Franklin
 * 1/29/2018
 */ 

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	/*
	 * had help with this part with the Roll-A-Ball turtorial on unity.
	 * https://unity3d.com/learn/tutorials/s/roll-ball-tutorial
	 */ 

	void Start () {

		offset = transform.position - player.transform.position;
		
	}
		
	void LateUpdate () {

		transform.position = player.transform.position + offset;
			
	}
}
