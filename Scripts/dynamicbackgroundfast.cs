using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicbackgroundfast : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/*Vector3 position = Vector3.zero;
		position.x = (Random.value*30);
		position.y = 3.3f;
		position.z = 0;
		Vector3 rotations = Vector3.zero;
		rotations.x = 0;
		rotations.y = 0;
		rotations.z = 0;
		var random = Random.value;
		Quaternion rotation = new Quaternion (0, 0, 0, 0);
		var player1 = Instantiate (spaceshipprefab, position, rotation);
		player1.transform.localScale = new Vector3 (1, 1, 1);
		player1.transform.localEulerAngles = rotations;
		*/
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		Vector2 offset = mat.mainTextureOffset;
		//offset.x = transform.position.x / transform.localScale.x / speed;
		//offset.y = transform.position.y / transform.localScale.y / speed;
		offset.y -= Time.deltaTime/(5)-(((1-Input.acceleration.y)*Time.deltaTime)/10);
		offset.x -= (((Input.acceleration.x)*Time.deltaTime)/4);
		mat.mainTextureOffset = offset;
		
	}
}
