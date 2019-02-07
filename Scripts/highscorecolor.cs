using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscorecolor : MonoBehaviour {
	public Text highscoretext;
	float colorchange;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		colorchange += 0.05f;
		if (colorchange > 1) {
			colorchange = 0;
		}
		highscoretext.color = Color.HSVToRGB (colorchange, 1, 1);
	}
}
