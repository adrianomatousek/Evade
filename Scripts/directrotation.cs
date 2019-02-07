using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directrotation : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0, Input.acceleration.x*45, 0);
	}
}
