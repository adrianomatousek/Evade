using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class callibrationangle : MonoBehaviour {
	public Text angle;
	public static float alpha;
	public Color textcolour;
	public static string calangle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//var getAlpha = GetComponent<Text> ().color;
		angle.text = calangle + "°";
		angle.color = new Color(1,1,1,alpha);
		if (alpha > 0) {
			alpha -= 0.01f;
		}
	}
}
