using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemies : MonoBehaviour {
	public GameObject enemy1;
	int timer;
	float timeLeft=1;
	// Use this for initialization
	void Start () {
		
	}// THIS SCRIPT IS NOT IN USE //
	
	// Update is called once per frame
	void FixedUpdate () {
	//if (timer % 100 == 0) {
		timeLeft = timeLeft-Time.deltaTime;
		if (timeLeft < 0) {
			Vector3 rotations = Vector3.zero;
			rotations.x = 90;
			rotations.y = 0;
			rotations.z = 0;

			Vector3 position = Vector3.zero;
			position.x = 35;
			position.y = 3;
			position.z = (Random.value * 18) - 9;

			Quaternion rotation = new Quaternion (0, 0, 0, 0);
			var enemy = Instantiate (enemy1, position, rotation);
			enemy.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
			enemy.transform.localEulerAngles = rotations;
			timeLeft = 1;
		}


		//	timer = 0;
		//}
		//timer++;
	}

}
