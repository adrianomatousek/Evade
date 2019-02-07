using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takeascreenshotvanish : MonoBehaviour {
	public Text takescreenshot;
	float vanish;
	// Use this for initialization
	void Start () {
		vanish = 1;
	}
	
	// Update is called once per frame
	void Update () {
		takescreenshot.color = new Color (1, 1, 1, vanish);
		vanish -= 0.02f;
	}
}
