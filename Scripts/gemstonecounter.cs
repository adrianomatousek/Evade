using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gemstonecounter : MonoBehaviour {
	public Text gemstonecount;

	// Use this for initialization
	void Start () {
	}
		
	// Update is called once per frame
	void Update () {
		gemstonecount.text = (PlayerPrefs.GetInt ("gemstonenumber")).ToString();
	}	
}
