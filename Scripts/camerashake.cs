using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour {
	public static int slowmocounter = 0;
	AudioSource audio;

	void Start (){
		slowmocounter = 0;
		audio = GetComponent<AudioSource>();
	}

	void FixedUpdate (){
		if (slowmocounter == 0) { //no slow mo --> pitch back to 1
			if (audio.pitch < 1) {
				audio.pitch += 0.01f;
			} 
		}
		else { //yes slow mo --> pitch to 0.7
				if (audio.pitch > 0.5f){
					audio.pitch -= 0.01f;
				}
		}
			
	}
}