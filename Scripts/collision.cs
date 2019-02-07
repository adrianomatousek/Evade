using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class collision : MonoBehaviour {
	public GameObject MainCamera;
	public GameObject originalshattered;
	public GameObject cursorshattered;
	public Rigidbody rb;
	public GameObject share;
	public GameObject pause;
	public GameObject skip;
	public GameObject sharegraphics;
	public int currentscore;
	public GameObject newHighScore;
	public int SelectedPlayer;
	public GameObject originals;
	public GameObject Revive;
	public Text ReviveVdeoCost;

	//public static int gamespeed;

	void OnCollisionEnter (Collision collision) {

		if(collision.gameObject.CompareTag("hostile")) {
			PlayerPrefs.SetInt ("lastscore", score.count);

			//GameObject.Find("Main Camera").SendMessage("DoShake");  
			share.SetActive (true);
			sharegraphics.SetActive (true);
			skip.SetActive (true);
			pause.gameObject.SetActive (false);

			//spawning fractured player
			var posplayer = GameObject.Find("SpaceshipMovement").transform.position; //calling position of original spaceship
			//var rotplayer = GameObject.Find("SpaceshipMovement").transform.rotation;
			//var rotplayerx = GameObject.Find("triangle").transform.rotation.x; //calling rotation of original spaceship
			//var rotplayery = GameObject.Find("triangle").transform.rotation.y; 
			var rotplayerz = GameObject.Find("triangle(Clone)").transform.rotation.z;
			score.collision = 1;
			//Vector3 rotations = Vector3.zero;
			//rotations.x = rotplayerx;
			//rotations.y = rotplayery;
			//rotations.z = rotplayerz;
			//Vector3 position = posplayer;
			if (score.count > PlayerPrefs.GetInt("highscore")){
				SelectedPlayer = (PlayerPrefs.GetInt ("whichPlayer"));
				PlayerPrefs.SetInt("highscore", score.count);
				newHighScore.SetActive (true);
			}

			//Quaternion rotation = new Quaternion (0,0,0,0);
			Instantiate (originalshattered, posplayer , Quaternion.Euler(0,-rotplayerz*360-180,0) ); //placing prefab
			//playershatteredmovement.transform.localScale = new Vector3 (1, 1, 1);
			//playershatteredmovement.transform.localEulerAngles = rotations;
		//speed	//playershatteredmovement.transform.Translate (Input.acceleration.x * Time.deltaTime * 10 + Input.acceleration.y * Time.deltaTime * 60, 0, Input.acceleration.x * Time.deltaTime * 10 - Input.acceleration.x * Time.deltaTime * 20);
			//playershatteredmovement.transform. (rotplayerx, rotplayery, rotplayerz);
			//print (originalspaceship.GetComponent<Rigidbody> ().velocity);
			Destroy (GameObject.Find("SpaceshipMovement")); //getting rid of original spaceship
			Revive.SetActive(true);
			ReviveVdeoCost.text = "\n"+pausemenu.revivecost+" ";
			currentscore = score.count;

			ShowInterstitial ();

			if (SelectedPlayer == 0) {
				var therotation = Quaternion.Euler(new Vector3(90, 90, 0));
				var pos = new Vector3 (0, 0, 0);
				Instantiate (originals, transform.position, therotation, transform);
			}
		}
	if(collision.gameObject.CompareTag("hostilefollower")) {
		//GameObject.Find("Main Camera").SendMessage("DoShake");  
		share.SetActive (true); 
		sharegraphics.SetActive (true);
		skip.SetActive (true); 
		pause.gameObject.SetActive (false);

		//spawning fractured player
		var posplayer = GameObject.Find("SpaceshipMovement").transform.position; //calling position of original spaceship
		//var rotplayer = GameObject.Find("SpaceshipMovement").transform.rotation;
		//var rotplayerx = GameObject.Find("triangle").transform.rotation.x; //calling rotation of original spaceship
		//var rotplayery = GameObject.Find("triangle").transform.rotation.y; 
		var rotplayerz = GameObject.Find("triangle(Clone)").transform.rotation.z;
		score.collision = 1;
		//Vector3 rotations = Vector3.zero;
		//rotations.x = rotplayerx;
		//rotations.y = rotplayery;
		//rotations.z = rotplayerz;
		//Vector3 position = posplayer;
		if (score.count > PlayerPrefs.GetInt("highscore")){
			PlayerPrefs.SetInt("highscore", score.count);
			newHighScore.SetActive (true);
		}
				

			PlayerPrefs.SetInt ("lastscore", score.count);

		//Quaternion rotation = new Quaternion (0,0,0,0);
			//Instantiate (cursorshattered, posplayer, GameObject.Find("triangle").transform.rotation);
			Instantiate (originalshattered, posplayer , Quaternion.Euler(0,-rotplayerz*360-180,0) ); //placing prefab
		//playershatteredmovement.transform.localScale = new Vector3 (1, 1, 1);
		//playershatteredmovement.transform.localEulerAngles = rotations;
		//speed	//playershatteredmovement.transform.Translate (Input.acceleration.x * Time.deltaTime * 10 + Input.acceleration.y * Time.deltaTime * 60, 0, Input.acceleration.x * Time.deltaTime * 10 - Input.acceleration.x * Time.deltaTime * 20);
		//playershatteredmovement.transform. (rotplayerx, rotplayery, rotplayerz);
		//print (originalspaceship.GetComponent<Rigidbody> ().velocity);
			Destroy (GameObject.Find("SpaceshipMovement")); //getting rid of original spaceship
			currentscore = score.count;
			Revive.SetActive(true);
			ReviveVdeoCost.text = "\n"+pausemenu.revivecost+" ";

			ShowInterstitial ();

			if (SelectedPlayer == 0) {
				var therotation = Quaternion.Euler(new Vector3(90, 90, 0));
				var pos = new Vector3 (0, 0, 0);
				Instantiate (originals, transform.position, therotation, transform);
			}

		}
	}


	public void ShowInterstitial () {
		if (PlayerPrefs.GetInt ("checkads") != 1) {
			if (1 == 1) {//System.DateTime.Now > new System.DateTime (2017, 5, 19)) { //y/m/d
				if (PlayerPrefs.GetInt ("PlayCount") > 4) {
					if (Application.platform != RuntimePlatform.WindowsEditor) {
						AdManager.Instance.ShowVideo ();
					}
					PlayerPrefs.SetInt ("PlayCount", 0);
				} else {
					PlayerPrefs.SetInt ("PlayCount", PlayerPrefs.GetInt ("PlayCount") + 1);
				} //ADMOB INTERSTITIAL
			}


		}
	}



}
	


