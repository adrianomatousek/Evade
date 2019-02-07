using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicbackgroundfastest : MonoBehaviour {

	void FixedUpdate () {

		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		Vector2 offset = mat.mainTextureOffset;
		//offset.x = transform.position.x / transform.localScale.x / speed;
		//offset.y = transform.position.y / transform.localScale.y / speed;
		offset.y -= Time.deltaTime/(10)-(((1-Input.acceleration.y)*Time.deltaTime)/20);
		mat.mainTextureOffset = offset;

	}
}
