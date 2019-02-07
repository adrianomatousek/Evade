using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int SelectedPlayer;
	public GameObject original;
	public GameObject cursor;
	public GameObject originals;
	public GameObject cursors;

	/*

	public GameObject original;
	public GameObject original;
	public GameObject original;
	*/

	void Start () {
		SelectedPlayer = (PlayerPrefs.GetInt ("whichPlayer"));
		if (SelectedPlayer == 0) {
			var therotation = Quaternion.Euler(new Vector3(90, 90, 0));
			var pos = new Vector3 (0, 0, 0);
			Instantiate (original, transform.position, therotation, transform);
		}
	}

	void Update () {
	}

}
