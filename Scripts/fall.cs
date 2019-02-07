using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour {
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		Time.timeScale = 1;
		rb.AddForce (new Vector3 (-15, 0, 0));
		if (transform.position.x < -30)
			Destroy (gameObject);
		
	}
}

