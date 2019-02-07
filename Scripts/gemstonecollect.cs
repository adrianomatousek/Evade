using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemstonecollect : MonoBehaviour {
	public int gemincrement;

	void OnTriggerEnter (Collider collision)
	{
		if (collision.gameObject.CompareTag ("spaceship")) {
			Destroy (transform.parent.gameObject);
			gemincrement = PlayerPrefs.GetInt ("gemstonenumber");
			PlayerPrefs.SetInt ("gemstonenumber", gemincrement + 1);  //incrementing gem count
			Destroy (gameObject);
		}
		if (collision.gameObject.CompareTag ("shield")) {
			Destroy (transform.parent.gameObject);
			gemincrement = PlayerPrefs.GetInt ("gemstonenumber");
			PlayerPrefs.SetInt ("gemstonenumber", gemincrement + 1);
			Destroy (gameObject);
		}
	}
}
