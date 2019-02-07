using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupinfection : MonoBehaviour {
	public GameObject explosioninfection;
	public GameObject sphere;

	// Use this for initialization

	void OnCollisionEnter (Collision collision)
	{

		if (collision.gameObject.CompareTag ("spaceship")) {
			Instantiate (explosioninfection, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z), new Quaternion(0,0,0,0));

			Instantiate (sphere, gameObject.transform.position, new Quaternion (0, 0, 0, 0));

			Destroy (gameObject);
			//Destroy (transform.parent.gameObject);
		}

		if (collision.gameObject.CompareTag ("shield")) {
			Instantiate (explosioninfection, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z), new Quaternion(0,0,0,0));
			Instantiate (sphere, gameObject.transform.position, new Quaternion (0, 0, 0, 0));
			Destroy (gameObject);
		}
	}
}
