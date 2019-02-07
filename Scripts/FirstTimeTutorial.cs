using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeTutorial : MonoBehaviour {
	public float waittime = 3;
	public GameObject Middle;
	public Vector3 newPosition;
	public int yes;
	public float timer;
	public GameObject arrow1;
	public GameObject arrow2;
	public GameObject poweruplist;
	public GameObject topeverything;
	public GameObject bottomeverything;
	public GameObject final;
	public Vector3 up;
	public Vector3 down;

	// Use this for initialization
	void Start () {
		Invoke ("SlowDown", 2f);
		//Invoke ("SpawnArrows", 3);
		up = new Vector3 (0, 300, 0);
		down = new Vector3 (0, -300, 0);
		newPosition = new Vector3 (300, 0, 0);
		StartCoroutine (MoveMiddle());
		StartCoroutine (timerrr ());
	}
		
	void SlowDown () {
		print ("slowed down");
		pausemenu.paused = 1;
		timer = 0;
	}


	IEnumerator MoveMiddle () {
		if (yes == 0) {
			yield return new WaitForSecondsRealtime (9);
			yes = 1;
		}
			

		for (int i = 1; i < 100000; i++) {		
			//Middle.transform.localPosition = new Vector3 (5 + Middle.transform.localPosition.x, 0, 0);
			Middle.transform.localPosition = Vector3.Lerp(Middle.transform.localPosition, newPosition, 0.04f);
			//Middle.transform.localPosition = Vector3.Lerp (Middle.transform.localPosition, newPosition, 4);
				if (yes == 2) {
					for (int e = 1; e < 300; e++) {
						//print (everythingelse.transform.localPosition);
						//Middle.transform.localPosition = new Vector3 (5 + Middle.transform.localPosition.x, 0, 0);
						topeverything.transform.localPosition = Vector3.Lerp (topeverything.transform.localPosition, up, 0.04f);
						bottomeverything.transform.localPosition = Vector3.Lerp (bottomeverything.transform.localPosition, down, 0.04f);
						//Middle.transform.localPosition = Vector3.Lerp (Middle.transform.localPosition, newPosition, 4);
						yield return new WaitForEndOfFrame ();
					}
			}
			yield return new WaitForEndOfFrame ();


		}



	}

	IEnumerator timerrr () {
		yield return new WaitForSecondsRealtime (9.2f);
		arrow1.SetActive (true);
		yield return new WaitForSecondsRealtime (1.5f);
		arrow2.SetActive (true);
		yield return new WaitForSecondsRealtime (2f);
		poweruplist.SetActive (true);

		yield return new WaitForSecondsRealtime (4f);
		final.SetActive (true);
		yes = 2;
		yield return new WaitForSecondsRealtime (1);
	}

	// Update is called once per frame
}
