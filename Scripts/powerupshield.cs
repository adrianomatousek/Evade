using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupshield : MonoBehaviour {
	public GameObject theshield;

	void OnCollisionEnter (Collision collision)
	{

		if (collision.gameObject.CompareTag ("spaceship")) {
			//print ("hello");
			Instantiate (theshield, gameObject.transform.position, new Quaternion (0, GameObject.Find("ROTATE").transform.rotation.y, 0, 0));
			Destroy (gameObject);
		}

		if (collision.gameObject.CompareTag ("shield")) {
			//print ("hello1");
			Instantiate (theshield, gameObject.transform.position, new Quaternion (0, GameObject.Find("ROTATE").transform.rotation.y, 0, 0));
			Destroy (gameObject);
		}

	}
}
