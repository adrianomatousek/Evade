
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public Text countText;
	public Text highscoreText;
	public Text highscorePause;
	int highscore;
	public static int collision = 0;
	public static int count;
	public int SwitchColour;
	public int fontsize;


	// Use this for initialization

	void Awake () {
		count = 0;
	}


	void Start () {
		collision = 0;
		SwitchColour = 1;
		fontsize = 30;
		countText.text = count.ToString ();
		InvokeRepeating("Count", 0.58f, 0.54f);
		highscore = PlayerPrefs.GetInt ("highscore");
		highscoreText.text = "new highscore!";
		highscorePause.text = "highscore " + highscore;
	}

	void FixedUpdate() {
		if (SwitchColour == 1) {
			if ((count % 25 == 0) && (count > 0)) { //When score is factor of 25, activate new change light colour
				lightcolourcontrol.ColourTime = 1;
				lightcolourcontrol.saturation = 0.8f;
				SwitchColour = 0;
				Invoke ("ColourWait", 5f);
				fontsize = 100; //Make it bigger
			} 
		} else if (fontsize > 30) {
			fontsize -= 7;
		}
		countText.fontSize = fontsize;
	}
		/*
		if (SwitchColour == 2) {
			Invoke ("ColourOff", 0.5f);
		} else {
			countText.fontSize = 30;
		}
		*/


	void Count () {
		if (collision == 1) {
			CancelInvoke ();
		} else {
		count = count + 1; //count + count * Time.deltaTime;
		countText.text = count.ToString ();// + "\nalpha";
		}
	}

	void ColourWait() {
		SwitchColour = 1;
	}

	void ColourOff() {
		SwitchColour = 0;
	}

}
