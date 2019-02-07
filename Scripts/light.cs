using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//if (transform.Rotate.y >)
		//transform.Rotate(Vector3*(40*Time.deltaTime));
		transform.Rotate (0, -20 * Time.deltaTime, 0);

	}

	}

