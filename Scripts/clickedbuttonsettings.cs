using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class clickedbuttonsettings : MonoBehaviour {
	public Transform clicked;
	public Button OFF;
	public Button ON;
	public Button EXTREME;
	public Button FANTASTIC;
	public Button GOOD;
	public Transform canvasposition;
	public Transform selectedbackground;
	public float check;
	public Light lightshadow;
	public float selected;
	public Slider sensitivity;

	// Use this for initialization
	void Start () {
		sensitivity.value = PlayerPrefs.GetFloat ("sensitivity",1);
		slowmo.slowmoactive = 0;
		if (PlayerPrefs.GetFloat ("ONorOFF") == 0) {
			ON.interactable = false;
			OFF.interactable = true;
		} else {
			ON.interactable = true;
			OFF.interactable = false;
		}

		if (PlayerPrefs.GetFloat ("clickedsetting") == 0) {
			EXTREME.interactable = false;
			FANTASTIC.interactable = true;
			GOOD.interactable = true;
		} else if (PlayerPrefs.GetFloat ("clickedsetting") == 1) {
			EXTREME.interactable = true;
			FANTASTIC.interactable = false;
			GOOD.interactable = true;
		} else if (PlayerPrefs.GetFloat ("clickedsetting") == 2) {
			EXTREME.interactable = true;
			FANTASTIC.interactable = true;
			GOOD.interactable = false;
		}
			

		//clicked.position = new Vector3 (0, (225 - PlayerPrefs.GetFloat ("clickedsetting")), 0) + canvasposition.position;
		//check = PlayerPrefs.GetFloat ("clickedsetting");
		selected = PlayerPrefs.GetFloat ("ONorOFF");
	}

	public void Extreme () {
		PlayerPrefs.SetFloat ("clickedsetting", 0);
		EXTREME.interactable = false;
		FANTASTIC.interactable = true;
		GOOD.interactable = true;
		QualitySettings.SetQualityLevel (4, true); //FANTASTIC
	}

	public void Fantastic () {
		PlayerPrefs.SetFloat ("clickedsetting", 1);
		EXTREME.interactable = true;
		FANTASTIC.interactable = false;
		GOOD.interactable = true;
		QualitySettings.SetQualityLevel (1, true); //FAST
	}

	public void Good () {
		PlayerPrefs.SetFloat ("clickedsetting", 2);
		EXTREME.interactable = true;
		FANTASTIC.interactable = true;
		GOOD.interactable = false;
		QualitySettings.SetQualityLevel (0, true); //FASTEST
	}
		

	public void ShadowOff () {
		lightshadow.shadows = LightShadows.None;
		PlayerPrefs.SetInt("toggleshadows", 0);
		PlayerPrefs.SetFloat ("ONorOFF", 1);
		ON.interactable = true;
		OFF.interactable = false;//new Vector3 (PlayerPrefs.GetFloat("ONorOFF") - 103, -272, 0) + canvasposition.position;
	}

	public void ShadowOn () {
		lightshadow.shadows = LightShadows.Soft;
		PlayerPrefs.SetInt("toggleshadows", 1);
		PlayerPrefs.SetFloat ("ONorOFF", 0);
		ON.interactable = false;
		OFF.interactable = true;// + ON1.position);//new vector3 (PlayerPrefs.GetFloat("ONorOFF") - 103, -272, 0) + canvasposition.position;
	}

	public void Tutorial () {
		pausemenu.paused = 0;
		PlayerPrefs.SetInt ("tutorialtoggle", 0);
		pausemenu.paused = 0;
		SceneManager.LoadScene ("Main");
		pausemenu.paused = 0;
		grrr ();
	}

	public void grrr () {
		pausemenu.paused = 0;
	}


	public void UpdateSensitivity () {
		PlayerPrefs.SetFloat ("sensitivity", sensitivity.value);
		//pausemenu.paused = 0;
		//Time.timeScale = 1;
		SpinningCube.playerspeed = PlayerPrefs.GetFloat ("sensitivity");
	}

}
