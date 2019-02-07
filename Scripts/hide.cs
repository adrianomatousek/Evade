using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("hidee");
	}
	

	// Update is called once per frame

	public IEnumerator hidee () {
		yield return new WaitForSecondsRealtime (3);
		gameObject.SetActive (false);
	}
		
}
