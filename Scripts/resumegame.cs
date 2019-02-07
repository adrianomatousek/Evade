using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumegame : MonoBehaviour {
	public GameObject canvas;


	public void resumenow (){
		canvas.gameObject.SetActive (false); 
		Time.timeScale = 1;

	}


}
