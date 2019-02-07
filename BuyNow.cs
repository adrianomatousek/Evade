using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNow : MonoBehaviour {
	public Text text;
	public string item = "Original";
	public int price = 0;
	public string type = "ship";
	public int ID;

	// Use this for initialization
	void Start () {
		UpdateInfo ();
	}

	public void UpdateInfo () {
		if (PlayerPrefs.GetInt (item) == 0) {
			text.text = "Buy: " + item + "\nPrice: " + price;
		} else {
			text.text = "Selected";
			string Active = "Active" + type;
			PlayerPrefs.SetInt (Active, ID);
		}
	}

	public void Buy () {
		if (PlayerPrefs.GetInt(item, 0) == 0) {
			if (PlayerPrefs.GetInt ("gemstonenumber") > price - 1) {
				PlayerPrefs.SetInt("gemstonenumber", PlayerPrefs.GetInt ("gemstonenumber") - price);
				PlayerPrefs.SetInt (item, 1);
				text.text = "Purchased!";
				string Active = "Active" + type;
				PlayerPrefs.SetInt (Active, ID);
			}
		}
	}


	public void Soriginal () {
		type = "Ship";
		ID = 0;
		item = "original";
		price = 0;
		//PlayerPrefs.SetInt (item, 0);
		UpdateInfo ();
	}
	public void MTtoRun () {
		type = "Music";
		ID = 0;
		item = "Time to Run";
		price = 0;
		UpdateInfo ();
	}
	public void Epic () {
		type = "Music";
		ID = 1;
		item = "Epic";
		price = 500;
		UpdateInfo ();
	}
	public void Dubstep() {
		type = "Music";
		ID = 2;
		item = "Dubstep";
		price = 100;
		UpdateInfo ();
	}
	public void NewBeginning () {
		type = "Music";
		ID = 3;
		item = "New Beginning";
		price = 10;
		UpdateInfo ();
	}
	public void Rumble () {
		type = "Music";
		ID = 4;
		item = "Rumble";
		price = 25;
		UpdateInfo ();
	}
	public void ExtremeAction () {
		type = "Music";
		ID = 5;
		item = "Extreme";
		price = 2;
		UpdateInfo ();
	}
}