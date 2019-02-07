using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Encrypt.keys=new string[5];
		Encrypt.keys[0]="23Wrudre";
		Encrypt.keys[1]="SP9DupHa";
		Encrypt.keys[2]="frA5rAS3";
		Encrypt.keys[3]="tHat2epr";
		Encrypt.keys[4]="jaw3eDAs";

		Encrypt.SetString("test_string", "Hello World");
		Debug.Log(Encrypt.GetString("test_string", "default"));

		Encrypt.SetInt("test_int", 500);
		Debug.Log(Encrypt.GetInt("test_int", -1));

		//Encrypt.SetFloat("test_float", 500.456);
		Debug.Log(Encrypt.GetFloat("test_float", -1f));
	}
	

}
