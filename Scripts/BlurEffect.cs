using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurEffect : MonoBehaviour {
	public Material BLUR;
	public static float size;

	// Use this for initialization
	void Start () {
		//BLUR.shader = Shader.Find ("Size");
		size = 0;
		BLUR.SetFloat ("_Size", size);
	}
	
	// Update is called once per frame
	void Update () {
		if (size < 6) {
			size += 0.1f;
			BLUR.SetFloat ("_Size", size);
		}
	}
}
