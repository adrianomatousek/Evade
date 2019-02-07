using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour {
	public Transform canvas;
	public Transform resumebutton;
	public Transform SettingsCanvas;
	public Transform AboutCanvas;
	public static float paused;

	public Button resume;
	public Button pause;

	float newColorr;
	float newColorg;
	float newColorb;
	float hello;
	float myalpha;
	float whileloop;
	float spawnresume;
	float mytimer;
	float spawnpause;
	float angle;
	float yinput;
	//int musiccounter = 0;
	//int soundcounter = 0;

	public static int revivecost;

	public GameObject aintgotdollar;

	public GameObject BLUR;
	public AudioSource music;
	public Toggle toggleformusic;
	public int fixmusictoggle;
	public Material BLURmat;
	public GameObject Sending;
	public GameObject Sucess;
	public GameObject Failed;
	public string messagetosend;
	public InputField entermessage;
	const string glyphs= "1234567890";


	void Start () {
		mytimer = 0;

		music = music.GetComponent<AudioSource>();

		fixmusictoggle = 0;
		if (PlayerPrefs.GetInt ("MusicToggle") == 0) {
			//MusicOff.SetActive (false);
			//MusicOn.SetActive (true);
			//toggleformusic.GetComponent<Toggle> ().isOn = true;
			fixmusictoggle = 1;
			music.mute = false;

		} else if (PlayerPrefs.GetInt ("MusicToggle") == 1) {
			//MusicOff.SetActive (true);
			//MusicOn.SetActive (false);
			toggleformusic.GetComponent<Toggle> ().isOn = false;
			music.mute = true;
		}
	}

	public void pausenow (){
		mytimer = 0;
		spawnresume = 1;
		BLURmat.SetFloat ("_Size", 0);
		BLUR.SetActive (true);
		BlurEffect.size = 0;
		canvas.gameObject.SetActive (true);
		//resumebutton.gameObject.SetActive (false);
		//resumebutton.gameObject.SetActive (true);
		resume.interactable=false;

		/*
		var randomnumber = Random.value * 6;  //for deciding whether to move either r, g or b
		var randomrgb = Random.value * 64 / 255; //for deciding how much to move our chosen color
		Image randomcolor = GameObject.Find ("PauseBackground").GetComponent<Image> ();
		myalpha = 0.3f;

		if (randomnumber < 1) {
			newColorr = 255 / 255;
			newColorg = 191 / 255;
			newColorb = 191 / 255 + randomrgb;	
		} else if (randomnumber < 2) {
			newColorr = 255 / 255;
			newColorg = 191 / 255 + randomrgb;
			newColorb = 191 / 255;
		} else if (randomnumber < 3) {
			newColorr = 191 / 255;
			newColorg = 255 / 255;
			newColorb = 191 / 255 + randomrgb;
		} else if (randomnumber < 4) {
			newColorr = 191 / 255 + randomrgb;
			newColorg = 255 / 255;
			newColorb = 191 / 255;
		} else if (randomnumber < 5) {
			newColorr = 191 / 255;
			newColorg = 191 / 255;
			newColorb = 255 / 255 + randomrgb;
		} else {
			newColorr = 191 / 255;
			newColorg = 191 / 255 + randomrgb;
			newColorb = 255 / 255;
		}


		randomcolor.color = new Color (newColorr, newColorg, newColorb);
		Color temp = randomcolor.color;
		myalpha = 0.3f;
		temp.a = myalpha;
		randomcolor.color = temp;
		*/

		paused = 1;




	}


	public void resumenow (){
		BLURmat.SetFloat ("_Size", 0);
		BlurEffect.size = 0;
		BLUR.SetActive (false);
		mytimer = 0;
		spawnpause = 1;
		spawnresume = 0;
		canvas.gameObject.SetActive (false);
		paused = 0;

		pause.interactable = false;
	}

	public void Facebook () {
		Application.OpenURL ("https://www.facebook.com/Evade-iOS-and-Android-101390667100603/");
	}

	public void Website () {
		Application.OpenURL ("http://evadeapp.000webhostapp.com/");
	}


	public void callibrate () {
		yinput = Input.acceleration.y;
		if (Input.acceleration.z > 0) {
			yinput = ((-2)-Input.acceleration.y);
		}
		//yinput = -0.5f; //reset to normal
		PlayerPrefs.SetFloat("callibration", (-120*yinput));
		print (Input.acceleration.y);	
		print (Input.acceleration.y*-120);

		angle = yinput * 360;
		callibrationangle.alpha = 1;
		angle = Mathf.Abs(angle);
		angle = Mathf.Round(angle);
		callibrationangle.calangle = angle.ToString ();
	}





	void Update () {
		if (spawnresume == 1) {
			if (mytimer > 8) {
				resume.interactable = true;
				mytimer = 0;
			}
			mytimer += 1;
			//print (Input.acceleration.y);
			//BACKGROUND Image randomcolor = GameObject.Find ("PauseBackground").GetComponent<Image> ();
			//BACKGROUND randomcolor.color = new Color (newColorr, newColorg, newColorb);
			//BACKGROUND Color temp = randomcolor.color;
			//BACKGROUND temp.a = myalpha;
			//BACKGROUND randomcolor.color = temp;
			//Image randomcolor = GameObject.Find ("PauseBackground").GetComponent<Image> ();
			//Color temp = randomcolor.color;
			/* BACKGROUND
			myalpha = myalpha + 0.002f;

			if (myalpha < 1) {
				temp.a = myalpha;
				randomcolor.color = temp;

			}
			else if (myalpha >= 1){
				hello = myalpha;
				myalpha = 2-myalpha;
				temp.a = myalpha;
				randomcolor.color = temp;
				myalpha = hello;
			}
			if (myalpha > 1.7) {
				myalpha = 0.3f;
				temp.a = myalpha;
			}
			*/ //BACKGROUND

		}
			
		if (spawnpause == 1) {
			if (mytimer > 8) {
				pause.interactable = true;
			}
			mytimer += 1;
		}


	}


	public void Restart () {
		SceneManager.LoadScene ("main");
	}

	public void GoSettings () {
		//mytimer = 0;
		//spawnpause = 1;
		spawnresume = 0;
		canvas.gameObject.SetActive (false);
		//paused = 0;
		//pause.interactable = false;
		SettingsCanvas.gameObject.SetActive (true);
	}

	public void GoAbout () {
		//mytimer = 0;
		//spawnpause = 1;
		spawnresume = 0;
		canvas.gameObject.SetActive (false);
		//paused = 0;
		//pause.interactable = false;
		AboutCanvas.gameObject.SetActive (true);
	}

	public void Back () {
		SettingsCanvas.gameObject.SetActive (false);
		canvas.gameObject.SetActive (true);
		spawnresume = 1;
	}

	public void BackAbout () {
		AboutCanvas.gameObject.SetActive (false);
		canvas.gameObject.SetActive (true);
		spawnresume = 1;
	}


	public void WatchVideo () {
		AdManager.Instance.ShowRewardVideo ();
	}

	public void ReviveWatchVideo () {
		AdManager.Instance.ShowRewardVideo ();
		AdManager.ReviveWatched = 1;
	}
		
	public void Store () {
		paused = 0;
		SceneManager.LoadScene ("Store");
	}

	public void PayRevive () {


		if (PlayerPrefs.GetInt ("gemstonenumber") > (revivecost-1)) {
			PlayerPrefs.SetInt ("gemstonenumber", PlayerPrefs.GetInt ("gemstonenumber") - revivecost);
			PlayerPrefs.SetInt ("revive", 1);
			SceneManager.LoadScene ("main");
		} else {
			aintgotdollar.SetActive (true);
		}
	}



	public void ToggleMusic () {
		print ("hellO");
		if (fixmusictoggle == 0) {
			fixmusictoggle = 1;
			print ("fix");
		} else if (PlayerPrefs.GetInt ("MusicToggle")==1) {
			//MusicOff.SetActive (false);
			//MusicOn.SetActive (true);
			PlayerPrefs.SetInt ("MusicToggle", 0);
			music.mute = false;
			print ("music on");
		} else {
			//MusicOff.SetActive (true);
			//MusicOn.SetActive (false);
			PlayerPrefs.SetInt ("MusicToggle", 1);
			music.mute = true;
			print ("music off");
		}
	
	}

	public void MessageUpdate () {
		messagetosend = entermessage.text;
		if (PlayerPrefs.GetInt ("idFirsTime", 0) == 0) {
			string id = "";
			int charAmount = Random.Range (50, 50); //set those to the minimum and maximum length of your string
			for (int i = 0; i < charAmount; i++) {
				id += glyphs [Random.Range (0, glyphs.Length)];
			}
			PlayerPrefs.SetString ("RandomId", id);
			PlayerPrefs.SetInt ("idFirsTime", 1);
		}
		//print (PlayerPrefs.GetString("RandomId"));
	}

	void GenerateInt () {

	}

	public void SendMessageNow () {
		Sending.SetActive (true);
		StartCoroutine (checkInternetConnection ((isConnected) => { 
			//print ("yes"); //sending RewardedVideosData
			print (messagetosend);
			string url1 = "https://evadeapp.000webhostapp.com/messages.php?"+"id="+PlayerPrefs.GetString("RandomId")+"&message="+messagetosend;
			print (url1);
			WWWForm form1 = new WWWForm ();
			form1.AddField ("var1", "value1");
			form1.AddField ("var2", "value2");
			WWW www1 = new WWW (url1, form1);
		}));

	}

	IEnumerator checkInternetConnection(System.Action<bool> action){
			WWW www = new WWW("https://google.com");
			yield return www;
			if (www.error != null) {
			Sending.SetActive(false);
			Failed.SetActive (true);
			//print ("not connected");
			//action (false);
			} else {
			//print ("connect");
			Sending.SetActive(false);
			Sucess.SetActive (true);
			action (true);
			}
		}
}
/*
	public void stopTime(){
		Time.timeScale = 0;
		` ("stop!");
	}

	public void startTime (){
		Time.timeScale = 1;
		print ("start!");
	}






	/*
	void Update () {
		if (mydelay > 0.2) {
			if (Input.GetKey (KeyCode.Escape)) {           //use for laptop - CHANGE BACKGROUND COLOR EVERYTIME
				mydelay = 0;
				myalpha = 0.3f;
				if (canvas.gameObject.activeInHierarchy == false) {
					canvas.gameObject.SetActive (true); 
					Time.timeScale = 0;
	
					var randomnumber = Random.value * 6;  //for deciding whether to move either r, g or b
					var randomrgb = Random.value * 64 / 255; //for deciding how much to move our chosen color
					Image randomcolor = GameObject.Find ("PauseBackground").GetComponent<Image> ();


					if (randomnumber < 1) {
						newColorr = 255 / 255;
						newColorg = 191 / 255;
						newColorb = 191 / 255 + randomrgb;	
					} else if (randomnumber < 2) {
						newColorr = 255 / 255;
						newColorg = 191 / 255 + randomrgb;
						newColorb = 191 / 255;
					} else if (randomnumber < 3) {
						newColorr = 191 / 255;
						newColorg = 255 / 255;
						newColorb = 191 / 255 + randomrgb;
					} else if (randomnumber < 4) {
						newColorr = 191 / 255 + randomrgb;
						newColorg = 255 / 255;
						newColorb = 191 / 255;
					} else if (randomnumber < 5) {
						newColorr = 191 / 255;
						newColorg = 191 / 255;
						newColorb = 255 / 255 + randomrgb;
					} else {
						newColorr = 191 / 255;
						newColorg = 191 / 255 + randomrgb;
						newColorb = 255 / 255;
					}


					randomcolor.color = new Color (newColorr, newColorg, newColorb);
					Color temp = randomcolor.color;
					myalpha = 0.3f;
					temp.a = myalpha;
					randomcolor.color = temp;

					// else 
					//{
					//	canvas.gameObject.SetActive(false);
					//	Time.timeScale = 1;
				} 
			}if (Input.touchCount > 0) {         
				mydelay = 0;
				myalpha = 0.3f;
				if (canvas.gameObject.activeInHierarchy == false) {
					canvas.gameObject.SetActive (true); 
					Time.timeScale = 0;

					var randomnumber = Random.value * 6;  //for deciding whether to move either r, g or b
					var randomrgb = Random.value * 64 / 255; //for deciding how much to move our chosen color
					Image randomcolor = GameObject.Find ("PauseBackground").GetComponent<Image> ();


					if (randomnumber < 1) {
						newColorr = 255 / 255;
						newColorg = 191 / 255;
						newColorb = 191 / 255 + randomrgb;	
					} else if (randomnumber < 2) {
						newColorr = 255 / 255;
						newColorg = 191 / 255 + randomrgb;
						newColorb = 191 / 255;
					} else if (randomnumber < 3) {
						newColorr = 191 / 255;
						newColorg = 255 / 255;
						newColorb = 191 / 255 + randomrgb;
					} else if (randomnumber < 4) {
						newColorr = 191 / 255 + randomrgb;
						newColorg = 255 / 255;
						newColorb = 191 / 255;
					} else if (randomnumber < 5) {
						newColorr = 191 / 255;
						newColorg = 191 / 255;
						newColorb = 255 / 255 + randomrgb;
					} else {
						newColorr = 191 / 255;
						newColorg = 191 / 255 + randomrgb;
						newColorb = 255 / 255;
					}


					randomcolor.color = new Color (newColorr, newColorg, newColorb);
					Color temp = randomcolor.color;
					myalpha = 0.3f;
					temp.a = myalpha;	
					randomcolor.color = temp;

					// else 
					//{
					//	canvas.gameObject.SetActive(false);
					//	Time.timeScale = 1;

				} 
			//}

		}	

		} else {            // DYNAMIC ALPHA BACKGROUND
			mydelay = mydelay + Time.deltaTime;
			Image randomcolor = GameObject.Find ("PauseBackground").GetComponent<Image> ();
			Color temp = randomcolor.color;
			myalpha = myalpha + 0.001f;

			if (myalpha < 1) {
				temp.a = myalpha;
				randomcolor.color = temp;
	
			}
			else if (myalpha >= 1){
				hello = myalpha;
				myalpha = 2-myalpha;
				temp.a = myalpha;
				randomcolor.color = temp;
				myalpha = hello;
			}
			if (myalpha > 1.7) {
				myalpha = 0.3f;
				temp.a = myalpha;
			}
		}

}
*/