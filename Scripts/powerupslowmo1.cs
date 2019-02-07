using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupslowmo1 : MonoBehaviour {
	public GameObject slowmo;

	void OnCollisionEnter (Collision collision)
	{

		if (collision.gameObject.CompareTag ("spaceship")) {
			//print ("hello");
			Instantiate (slowmo, gameObject.transform.position, new Quaternion (0, 0, 0, 0));
			Destroy (gameObject);
		}

		if (collision.gameObject.CompareTag ("shield")) {
			//print ("hello1");
			Instantiate (slowmo, gameObject.transform.position, new Quaternion (0, 0, 0, 0));
			Destroy (gameObject);
		}

	}
}
