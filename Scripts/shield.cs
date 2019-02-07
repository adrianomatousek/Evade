using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("destroy", 6.1f);
		//GameObject.Find ("Cube").GetComponent<BoxCollider>().enabled = false;

	}

	void destroy ()
	{
		GameObject.Find ("Cube").GetComponent<BoxCollider>().enabled = true;
		//gameObject.SetActive (false);
		Destroy (gameObject);
	}

	void Update () {
		GameObject.Find ("Cube").GetComponent<BoxCollider>().enabled = false;
		transform.position = GameObject.Find ("ShieldPosition").transform.position;
	}

}


