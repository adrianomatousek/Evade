using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {
	//rotation gyro;
	//public float xvalue;
	// Use this for initialization
	//public float temp;
	public GameObject Target;



	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*
		//Quaternion rotation Quaternion (0, 90, 0, 0);
		Vector3 rotations = Vector3.zero;
		rotations.x = 90;
		rotations.y = 90 + Input.acceleration.z*180;
		rotations.z = 0;
		transform.localEulerAngles = rotations;
		*/
		//transform.rotation (0, 0, -Input.acceleration.x*40);

		/*
		Vector3 rotations = Vector3.zero;
		rotations.y = temp;//Input.acceleration.x*45;
		rotations.x = 0;
		rotations.z = 0;

		xvalue = rotations.y - transform.rotation.y;

		transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0,xvalue,0,0),0.01f);	

		//var targetRotation = Quaternion.LookRotation(rotations.y - transform.position, Vector3.up);
		//transform.rotation = Quaternion.Slerp(transform.rotation, rotations.y, Time.deltaTime*2);

		//Input.acceleration. */
		transform.rotation = Quaternion.Slerp(transform.rotation, Target.transform.rotation, Time.deltaTime * 2);

		//transform.rotation = Quaternion.Euler (0.5f, 0, 0);
		//transform.Rotate(0,1,0);
	}
}
