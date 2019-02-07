using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmo : MonoBehaviour {
	public static float slowmoactive=0;
	// Use this for initialization
	void Start () {
		Invoke ("destroy", 4);
		Invoke ("counter",3.3f);
		slowmoactive = 0;
		camerashake.slowmocounter += 1;
	}


	void destroy(){
		slowmoactive = 0;     //boleon for pause
		Destroy (gameObject);
	}
			
	void counter (){
		camerashake.slowmocounter -= 1;
	}

	void FixedUpdate () {
		slowmoactive = 1; //boleon for pause
	}
}
