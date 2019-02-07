using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour {
	public GameObject sphere;
	public GameObject explosion;

	void OnCollisionEnter (Collision collision)
	{

		if (collision.gameObject.CompareTag ("spaceship")) {
			Instantiate (sphere, gameObject.transform.position, new Quaternion(0,0,0,0));

			Instantiate (explosion, gameObject.transform.position, new Quaternion (0, 0, 0, 0));

			Destroy (gameObject);
					//Destroy (transform.parent.gameObject);
		}

		if (collision.gameObject.CompareTag ("shield")) {
			Instantiate (sphere, gameObject.transform.position, new Quaternion(0,0,0,0));

			Instantiate (explosion, gameObject.transform.position, new Quaternion (0, 0, 0, 0));

			Destroy (gameObject);
		}
			
	}
}
		
