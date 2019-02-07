using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightcolourcontrol : MonoBehaviour {
	public static float ColourTime;
	public float ColourSwitch;
	public Light colourlight;
	public float hue;
	public static float saturation;
	public float brightness;
	public float random;

	// Use this for initialization
	void Start () {
		ColourTime = 0;
		colourlight = GetComponent<Light> ();
		random = Random.value;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (ColourTime == 1) {
			hue = random;
			//Color changecolour = gameObject.GetComponent<Light> ();
			//saturation = 0.8f;
			colourlight.intensity = 8;
			//colourlight.color = Color.(0,0,1,1); //Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 1));
			Invoke ("ChangeTime", 0.4f);
			hue = hue + 0.005f;
		}
		if (colourlight.intensity > 1.4f) {
			colourlight.intensity -= 0.1f;
		}
		if (saturation > 0) {
			saturation = saturation - 0.01f;
			//colourlight.color = Color.HSVToRGB (hue, saturation, 0.8f);
		}
		colourlight.color = Color.HSVToRGB (hue, saturation, 0.8f);
	}

	void ChangeTime () {
		ColourTime = 0;
		//colourlight.color = Color.white;
		random = Random.value;
	}



}
