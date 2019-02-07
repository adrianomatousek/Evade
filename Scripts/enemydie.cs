using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydie : MonoBehaviour {
	public GameObject infectionring;
	// Use this for initialization
	void Start () {
		
	}






	// Update is called once per frame
	void FixedUpdate () {
		if(transform.position.x < -30)

			Destroy(gameObject);
	}

	void OnTriggerEnter (Collider collision)
	{

		if (collision.gameObject.CompareTag ("bombradius")) {


			Destroy (gameObject);

			//Destroy (transform.parent.gameObject);
			}
		if (collision.gameObject.CompareTag ("infection")) {
			if (GetComponent<infectedfollow> () == null) {
				gameObject.AddComponent<infectedfollow> ();
				Instantiate (infectionring, gameObject.transform.position, new Quaternion (0, 0, 0, 0), transform);
			}
			//gameObject.transform.parent = gameObject.transform
			Destroy (GetComponent<enemyscript> ());	
			Destroy (GetComponent<enemydie> ());
		}
	}
}