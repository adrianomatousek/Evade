using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextWrite : MonoBehaviour {
	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";
	public float startdelay;
	public int yes;

	// Use this for initialization
	void Start () {
		StartCoroutine(ShowText());	
	}

	IEnumerator ShowText(){
		if (yes == 0) {
			yield return new WaitForSecondsRealtime (startdelay);
			yes = 1;
		}
		for(int i = 1; i < (fullText.Length +1); i++){
			currentText = fullText.Substring(0,i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSecondsRealtime(delay);
		}
	}
}

