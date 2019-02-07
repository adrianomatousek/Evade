using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class removeTezt : MonoBehaviour {
	int timer;
	string hello;
	float vanish;

	// Use this for initialization
	void Start () {
		vanish = 1;
		timer = 0;
		Invoke ("Fade", 2.5f);
		Invoke ("Delete", 3.5f);
	}

	void FixedUpdate () {
		if (timer == 1) {
			gameObject.GetComponent<Text>().color = new Color (1, 1, 1, vanish);
			vanish -= 0.02f;
		}
	}
	
	// Update is called once per frame
	void Delete () {
		gameObject.SetActive (false);
	}

	void Fade () {
		timer = 1;
	}
}
