using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sending : MonoBehaviour {
	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";
	public float startdelay;
	public int yes;
	int count = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine(ShowText());
	}

	IEnumerator ShowText(){
		if (yes == 0) {
			yield return new WaitForSecondsRealtime (startdelay);
			yes = 1;
		}
		for(int i = 0; i < 500; count++){
			currentText = fullText.Substring(0,i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSecondsRealtime(delay);
			i += 1;
			if (count > 3) {
				i = 0;
				count = 0;
			}
		}
	}

}

