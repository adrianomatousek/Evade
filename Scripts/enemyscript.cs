using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour {
	public Transform target;
	public Rigidbody rb;
	public static float speed;
// Use this for initialization
	void Start () {
		//speed = 8;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt(target);
		transform.Translate(Vector3.forward*speed*Time.deltaTime); 
		//rb.AddForce(Vector3.forward*10000f*Time.deltaTime);

	}
}
