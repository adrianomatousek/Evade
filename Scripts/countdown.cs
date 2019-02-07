using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour {
	public Text count;
	public float time = 3;
	public float yes;
	public float alpha1;
	public GameObject Tutorial;
	public Image help;
	public Text meee;
	public Text me2;
	public int me3;

	// Use this for initialization
	void Start () {
		alpha1 = 1;
		StartCoroutine (hello());
	}
	
	// Update is called once per frame
	void Update () {
		//print (time);
		//time -= 0.15f*Time.deltaTime;
		//yes = Mathf.Round (time * 100) / 100;
		//count.text = yes.ToString();
		count.color = new Color(1,1,1,alpha1);
		help.color = new Color (1, 1, 1, alpha1);
		meee.color = new Color (1, 1, 1, alpha1);
		me2.color = new Color (1, 1, 1, alpha1);

		if (me3 == 1) {

			if (alpha1 > 0) {
				alpha1 -= 0.08f;
			}
		}
		if (yes < 0) {
			pausemenu.paused = 0;
			PlayerPrefs.SetInt ("tutorialtoggle", 1);
		}
	}

	IEnumerator hello () {
		yes = 5;
		count.text = yes.ToString();
		yield return new WaitForSecondsRealtime (0.8f);
		yes = 4;
		count.text = yes.ToString();
		yield return new WaitForSecondsRealtime (0.8f);
		yes = 3;
		count.text = yes.ToString();
		yield return new WaitForSecondsRealtime (0.8f);
		yes = 2;
		count.text = yes.ToString();
		yield return new WaitForSecondsRealtime (0.8f);
		yes = 1;
		count.text = yes.ToString();
		yield return new WaitForSecondsRealtime (0.8f);
		yes = -1;
		count.text = "GO!";
		me3 = 1;
		yield return new WaitForSecondsRealtime (0.8f);
		Tutorial.SetActive (false);
		StopCoroutine (hello ());
	}
}
