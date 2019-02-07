using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using admob;

public class SpinningCube : MonoBehaviour {
	//public Rigidbody rb;
	float initialAccelX;
	float initialAccelY;
	int timer;
	public GameObject gem;
	public GameObject prefabRock1;
	public GameObject prefabRock2;
	public GameObject prefabRock3;
	public GameObject prefabRock4;
	public GameObject prefabRock5;
	public GameObject prefabRock6;
	public GameObject prefabRock7;
	public GameObject prefabRock8;
	public GameObject prefabRock9;
	public GameObject prefabRock10;
	public GameObject enemy1;
	public GameObject bomb;
	public GameObject infection;
	public GameObject shield;
	public GameObject slowmop;
	public Rigidbody rb;
	int tempscore;
	public static float death;
	public static float slowmomusic;
	public Light lightshadow;
	public AudioSource musictoggle;
	public float speed;
	public GameObject tutorial;
	public float enemyspeed;
	public float enemydelay;
	public float PowerUpChance;
	public float randomPowerUpDecider;
	public float randomRockDecider;
	public GameObject selectpowerup;
	public GameObject selectrock;
	public float GemDecider;
	public static float playerspeed;
	public GameObject AdManager1;
	public float yinput;
	public static int watchedrewardvideo;
	public GameObject speedthingsup;
	public GameObject comingforyou;
	public AudioSource camerasound;
	public AudioClip WillSarg;
	public AudioClip NewBeginning;
	public AudioClip Dubstep;
	public AudioClip Rumble;
	public AudioClip ExtremeAction;
	public AudioClip Epic;

		void Start() {
		//PlayerPrefs.SetInt ("SelectedSong", 0);
		if (PlayerPrefs.GetInt ("ActiveMusic") == 0) {
			camerasound.clip = WillSarg;
			camerasound.Play ();
		} else if (PlayerPrefs.GetInt ("ActiveMusic") == 1) {
			camerasound.clip = Epic;
			camerasound.Play ();
		} else if (PlayerPrefs.GetInt ("ActiveMusic") == 2) {
			camerasound.clip = Dubstep;
			camerasound.Play ();
		} else if (PlayerPrefs.GetInt ("ActiveMusic") == 3) {
			camerasound.clip = NewBeginning;	
			camerasound.Play ();
		} else if (PlayerPrefs.GetInt ("ActiveMusic") == 4) {
			camerasound.clip = Rumble;
			camerasound.Play ();
		} else if (PlayerPrefs.GetInt ("ActiveMusic") == 5) {
			camerasound.clip = ExtremeAction;
			camerasound.Play ();
		}

		//AdManager1.GetComponent<AdManager> ().loadInterstitial ();
		pausemenu.revivecost = 5;
		//score.count = 60;
		enemyscript.speed = 9;
		AdManager.ReviveWatched = 0;
		//PlayerPrefs.SetInt ("gemstonenumber", 200);
		if (GameObject.Find ("AdManager(Clone)") != null) {
			//its is already there
		} else {
			Instantiate (AdManager1);
		}

		//Admob.Instance ().loadInterstitial ();

		/*
		if (Application.platform != RuntimePlatform.WindowsEditor) {
			if (!Admob.Instance ().isInterstitialReady ()) {
				Admob.Instance ().loadInterstitial ();
			}
		} */

		if (PlayerPrefs.GetInt ("revive") == 1) {
			PlayerPrefs.SetInt ("revive", 0);
			pausemenu.revivecost = 15;
			score.count = PlayerPrefs.GetInt ("lastscore");
		}
						
		//PlayerPrefs.SetInt ("highscore", 1);  //highscore everytime
		slowmo.slowmoactive = 0;
		playerspeed = ((PlayerPrefs.GetFloat("sensitivity",1)));
		
		Invoke ("SpawnEnemy", enemydelay + 1);
		Invoke ("SpawnPowerUp", 1);
		Invoke ("SpawnMeteor", 1.5f);

		string url = "https://evadeapp.000webhostapp.com/connect2.php?" + PlayerPrefs.GetInt ("lastscore"); //currentscore.ToString();
		print (url); //sending highscore data
		WWWForm form = new WWWForm();
		form.AddField("var1", "value1");
		form.AddField("var2", "value2");
		WWW www = new WWW(url, form);

		StartCoroutine (checkInternetConnection ((isConnected) => { 
			//print ("yes"); //sending RewardedVideosData
			if (watchedrewardvideo > 0) {
				watchedrewardvideo -= 1;
				string url1 = "https://evadeapp.000webhostapp.com/watchedvideos.php?";

				WWWForm form1 = new WWWForm ();
				form1.AddField ("var1", "value1");
				form1.AddField ("var2", "value2");
				WWW www1 = new WWW (url1, form1);
			}
		}));




		//PlayerPrefs.SetInt ("tutorialtoggle", 0);
		if (PlayerPrefs.GetInt ("tutorialtoggle") == 0) {
			tutorial.SetActive (true);
		}



		SaveLoad.Money += 1;
		speed = 50;
		if (PlayerPrefs.GetInt ("toggleshadows") == 1) {
			lightshadow.shadows = LightShadows.Soft;
		} 
		if (PlayerPrefs.GetInt ("toggleshadows") == 0) {
			lightshadow.shadows = LightShadows.None;
		}

		/*
		if (PlayerPrefs.GetInt ("PlayCount") > 1) {
			if (Application.platform != RuntimePlatform.WindowsEditor) {
				AdManager.Instance.ShowVideo ();
			}
			PlayerPrefs.SetInt ("PlayCount", 0);
		} else {
			PlayerPrefs.SetInt ("PlayCount", PlayerPrefs.GetInt ("PlayCount") + 1);
		} ADMOB INTERSTITIAL
		*/
		
		rb = GetComponent<Rigidbody>();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		death = 1;
		slowmo.slowmoactive = 0;

		if (PlayerPrefs.GetFloat ("clickedsetting") == 0) {
			QualitySettings.SetQualityLevel (4, true);
		} 
		if (PlayerPrefs.GetFloat ("clickedsetting") == 1) {
			QualitySettings.SetQualityLevel (1, true);
		}
		if (PlayerPrefs.GetFloat ("clickedsetting") == 2) {
			QualitySettings.SetQualityLevel (0, true);
		}


		musictoggle = musictoggle.GetComponent<AudioSource>();

		CheckMusic ();
		/*
		if (Application.platform != RuntimePlatform.WindowsEditor) {
			AdManager.Instance.ShowBanner ();
		} ADMOB BANNER - Should be moved to collision script :)) (more clicks)
		*/

	}

	void CheckMusic () {
		if (PlayerPrefs.GetInt ("MusicToggle") == 0) {
			musictoggle.mute = false;

		} else {
			musictoggle.mute = true;
		}
	}


	void Awake () {
		Application.targetFrameRate = 40;
	}

	void FixedUpdate() {
		
		//rb.AddForce(new Vector3(Input.acceleration.y*Time.deltaTime*600, 0,-Input.acceleration.x*Time.deltaTime*600));
		//rb.AddTorque(new Vector3(0,Input.acceleration.x*Time.deltaTime*360, 0));
		//transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*10 + initialAccelY, 0, initialAccelX-Input.GetAxis("Vertical")*Time.deltaTime*10);
		//print("y"+(Input.acceleration.y*Time.deltaTime*10 + initialAccelY) + "x"+( - Input.acceleration.x*Time.deltaTime*10 + initialAccelX));

		if (PlayerPrefs.GetInt("tutorialtoggle") > 0) {
			if (Application.platform == RuntimePlatform.WindowsEditor) {
				transform.Translate (Input.GetAxis ("Vertical") * Time.deltaTime * 40, 0, -Input.GetAxis ("Horizontal") * Time.deltaTime * 40);
			} 
			else {
				yinput = Input.acceleration.y;
				if (Input.acceleration.z > 0) {
					yinput = (-1+(-1-Input.acceleration.y));
				}
				//transform.Translate (yinput * Time.deltaTime * (60+60*playerspeed) * 1.2f + (Time.deltaTime * PlayerPrefs.GetFloat("callibration", 60)*playerspeed), 0, - Input.acceleration.x * Time.deltaTime * (45+45*playerspeed));
				transform.Translate (yinput * Time.fixedDeltaTime * (60+60*playerspeed) * 1.2f + (Time.fixedDeltaTime * PlayerPrefs.GetFloat("callibration", 60)*playerspeed), 0, - Input.acceleration.x * Time.fixedDeltaTime * (45+45*playerspeed));
			}

		}
	}



	void Update () {
		
		if (speed > 2) {
			gameObject.transform.Translate (speed * Time.fixedDeltaTime * 2, 0, 0);
			speed -= 2;
		}

		if (pausemenu.paused == 1) {
			death = 0;
		} else {
			if (slowmo.slowmoactive == 1) {   	//checking if slowmo is active...
				death = 0.5f;
				Time.fixedDeltaTime = 0.015f;
			} else {
				death = 1;
				Time.fixedDeltaTime = 0.02f;
			}
		}
		Time.timeScale = death;

	}


	public void SpawnEnemy () {
		Vector3 rotations = Vector3.zero;
		rotations.x = 0;
		rotations.y = 0;
		rotations.z = 0;
		var random = Random.value;

		if (score.count < 25) {
			enemyscript.speed = 8;
			enemydelay = 2;
			PowerUpChance = 0;
		} else if (score.count < 50) {
			enemyscript.speed = 9;
			enemydelay = 1.5f;
			PowerUpChance = 1;
		} else if (score.count < 68f) {
			enemyscript.speed = 9f;
			enemydelay = 1;
			PowerUpChance = 2;
		} else if (score.count < 70) {
			enemyscript.speed = 9f;
			enemydelay = 1;
			PowerUpChance = 2;
			speedthingsup.SetActive (true);
		} else if (score.count < 80) {
			enemyscript.speed = 11f;
			enemydelay = 0.75f;
			PowerUpChance = 3;
		} else if (score.count < 100) {
			enemyscript.speed = 11f;
			enemydelay = 0.75f;
			PowerUpChance = 3;
		} else if (score.count < 115) {
			enemyscript.speed = 12;
			enemydelay = 10f;
			PowerUpChance = 9;
			comingforyou.SetActive (true);
		}else if (score.count < 125) {
			enemyscript.speed = 25;
			enemydelay = 5f;
			PowerUpChance = 3;
		} else if (score.count < 150) {
			enemyscript.speed = 13;
			enemydelay = 0.75f;
			PowerUpChance = 3;
		} else if (score.count < 175) {
			enemyscript.speed = 14;
			enemydelay = 0.75f;
			PowerUpChance = 3;
		} else if (score.count < 200) {
			enemyscript.speed = 15;
			enemydelay = 0.75f;
			PowerUpChance = 3;
		} else if (score.count < 225) {
			enemyscript.speed = 16;
			enemydelay = 0.75f;
			PowerUpChance = 3;
		} else if (score.count < 250) {
			enemyscript.speed = 17;
			enemydelay = 0.75f;
			PowerUpChance = 3;
		} else if (score.count < 275) {
			enemyscript.speed = 18;
			enemydelay = 0.75f;
			PowerUpChance = 3;
		} else if (score.count < 300) {
			enemyscript.speed = 19;
			enemydelay = 0.75f;
			PowerUpChance = 3;
		}
		//Spawning Enemy
		if (random < 0.3) { //top
			Vector3 position = Vector3.zero;
			position.x = 43;
			position.y = 4.5f;
			position.z = (Random.value * 31) - 15.5f;
			Quaternion rotation = new Quaternion (0, 0, 0, 0);
			var enemy = Instantiate (enemy1, position, rotation);
			enemy.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
			enemy.transform.localEulerAngles = rotations;

		} else if (random < 0.6) {   //right side
			Vector3 position = Vector3.zero;
			position.x = (Random.value * 35.5f);
			position.y = 4.5f;
			position.z = 20f;
			Quaternion rotation = new Quaternion (0, 0, 0, 0);
			var enemy = Instantiate (enemy1, position, rotation);
			enemy.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
			enemy.transform.localEulerAngles = rotations;

		} else if (random > 0.6) { //left side
			Vector3 position = Vector3.zero;
			position.x = (Random.value * 35.5f);
			position.y = 4.5f;
			position.z = -20;			
			Quaternion rotation = new Quaternion (0, 0, 0, 0);
			var enemy = Instantiate (enemy1, position, rotation);
			enemy.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
			enemy.transform.localEulerAngles = rotations;
		}
		Invoke ("SpawnEnemy", enemydelay);
	}

	public void SpawnPowerUp () { //also spawns gem
		randomPowerUpDecider = Random.value*100; //randomize which powerup spawns
		GemDecider = Random.value*100;

		if (PowerUpChance == 0) {
			if (randomPowerUpDecider < 75) {
				selectpowerup = bomb;
			} else if (randomPowerUpDecider < 82) {
				selectpowerup = infection;
			} else if (randomPowerUpDecider < 89) {
				selectpowerup = slowmop;
			} else if (randomPowerUpDecider < 100) {
				selectpowerup = shield;
			}
		} else if (PowerUpChance == 1) {
			if (randomPowerUpDecider < 50) {
				selectpowerup = bomb;
			} else if (randomPowerUpDecider < 59) {
				selectpowerup = infection;
			} else if (randomPowerUpDecider < 79) {
				selectpowerup = slowmop;
			} else if (randomPowerUpDecider < 100) {
				selectpowerup = shield;
			}
		} else if (PowerUpChance == 2) {
			if (randomPowerUpDecider < 20) {
				selectpowerup = bomb;
			} else if (randomPowerUpDecider < 60) {
				selectpowerup = infection;
			} else if (randomPowerUpDecider < 79) {
				selectpowerup = slowmop;
			} else if (randomPowerUpDecider < 100) {
				selectpowerup = shield;
			}
		} else if (PowerUpChance == 3) {
			if (randomPowerUpDecider < 5) {
				selectpowerup = bomb;
			} else if (randomPowerUpDecider < 65) {
				selectpowerup = infection;
			} else if (randomPowerUpDecider < 89) {
				selectpowerup = slowmop;
			} else if (randomPowerUpDecider < 100) {
				selectpowerup = shield;
			}
		} else if (PowerUpChance == 9) {
			if (randomPowerUpDecider < 50) {
				selectpowerup = bomb;
			} else if (randomPowerUpDecider < 100) {
				selectpowerup = infection;
			} else if (randomPowerUpDecider < 89) {
				selectpowerup = slowmop;
			} else if (randomPowerUpDecider < 100) {
				selectpowerup = shield;
			}
		}
		Vector3 rotations = Vector3.zero; //randomize powerup position
		rotations.x = 90;
		rotations.y = (Random.value * 360);
		rotations.z = 0;
		Vector3 position = Vector3.zero;
		position.x = 45;
		position.y = 4.5f;
		position.z = (Random.value * 31) - 15.5f;
		Quaternion rotation = new Quaternion (90, 0, 0, 0);

		var powerup = Instantiate (selectpowerup, position, rotation);
		powerup.transform.localScale = new Vector3 (12, 12, 24);
		powerup.transform.localEulerAngles = rotations;
		Invoke ("SpawnPowerUp", 4);

		if (GemDecider < 5) { // 1/20 powerups will spawn gem
			Vector3 rotationsG = Vector3.zero; //randomize powerup position
			rotationsG.x = 90;
			rotationsG.y = (Random.value * 360);
			rotationsG.z = 0;
			Vector3 positionG = Vector3.zero;
			positionG.x = 45;
			positionG.y = 5.8f;
			positionG.z = (Random.value * 31) - 15.5f;
			Quaternion rotationG = new Quaternion (180, -90, -180, 0);

			var powerupG = Instantiate (gem, positionG, rotationG);
			powerupG.transform.localScale = new Vector3 (1.2f, 1.5f, 1.2f);
			powerupG.transform.localEulerAngles = rotationsG;
		}
	}

	public void SpawnMeteor () {
		randomRockDecider = Random.value * 10;
		Quaternion rotation = new Quaternion (90, 0, 0, 0);

		if (randomRockDecider < 1) {
			selectrock = prefabRock1;
		} else if (randomRockDecider< 2) {
			selectrock = prefabRock1;
		}else if (randomRockDecider< 3) {
			selectrock = prefabRock2;
		}else if (randomRockDecider< 4) {
			selectrock = prefabRock3;
		}else if (randomRockDecider< 5) {
			selectrock = prefabRock4;
		}else if (randomRockDecider< 6) {
			selectrock = prefabRock5;
		}else if (randomRockDecider< 7) {
			selectrock = prefabRock6;
		}else if (randomRockDecider< 8) {
			selectrock = prefabRock7;
		}else if (randomRockDecider< 9) {
			selectrock = prefabRock4;
		} else if (randomRockDecider < 10) {
			selectrock = prefabRock9;
		}

		Vector3 rotations = Vector3.zero;
		rotations.x = 90;
		rotations.y = (Random.value * 360);
		rotations.z = 0;

		Vector3 position = Vector3.zero;
		position.x = 45;
		position.y = 4.5f;
		position.z = (Random.value * 31) - 15.5f;

		var Rock1 = Instantiate (selectrock, position, rotation);
		Rock1.transform.localScale = new Vector3 (10, 10, 5);
		Rock1.transform.localEulerAngles = rotations;
		Rock1.AddComponent<fall> ();
		Invoke ("SpawnMeteor", 2);
	}


	IEnumerator checkInternetConnection(System.Action<bool> action){
		WWW www = new WWW("https://google.com");
		yield return www;
		if (www.error != null) {
			//print ("not connected");
			//action (false);
		} else {
			//print ("connect");
			action (true);
		}
	}



}
