using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;
using UnityEngine.UI;

public class reviveCheckVideo : MonoBehaviour {
	public Button video;

	// Use this for initialization
	void Start () {
		if (Admob.Instance ().isRewardedVideoReady ()) {
			gameObject.SetActive (false);
		} else {
			video.interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
