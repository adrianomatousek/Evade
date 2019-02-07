using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadnewscene : MonoBehaviour {
	// Use this for initialization
	public float hello;
	public GameObject Target;
	float newPos;
	public float rotatespeed;
	public float whichway;


	void Update () {
		if (hello == 1) {
			Time.timeScale = 0.5f;  //slow mo :D
			rotatespeed = rotatespeed + 0.2f + Time.deltaTime * 5; //makes rotation speed increase

			if (whichway > 0) {  //both quadrants on the left

				var targetRotation = Quaternion.LookRotation (gameObject.transform.position - GameObject.Find ("Main Camera").transform.position);
				// Smoothly rotate towards the target point.
				GameObject.Find ("Main Camera").transform.rotation = Quaternion.Slerp (GameObject.Find ("Main Camera").transform.rotation, targetRotation, rotatespeed * Time.deltaTime);
				GameObject.Find ("Main Camera").transform.Translate (8 * Time.deltaTime, 0, 3 * Time.deltaTime); //first (x) is rotating , 2nd (z) is zooming in

			} else { //both quadrants on the right

				var targetRotation = Quaternion.LookRotation (gameObject.transform.position - GameObject.Find ("Main Camera").transform.position);
				// Smoothly rotate towards the target point.
				GameObject.Find ("Main Camera").transform.rotation = Quaternion.Slerp (GameObject.Find ("Main Camera").transform.rotation, targetRotation, rotatespeed * Time.deltaTime);
				GameObject.Find ("Main Camera").transform.Translate (-8 * Time.deltaTime, 0, 3 * Time.deltaTime);


			}


			//GameObject.Find("Main Camera").transform.position = Vector3.Lerp(transform.position, Target.transform.position, 2000000000000);
			//GameObject.Find("Main Camera").transform.Translate (new Vector3(Time.deltaTime*(-GameObject.Find("Main Camera").transform.position.x-Target.transform.position.x),Time.deltaTime*(-GameObject.Find("Main Camera").transform.position.y-Target.transform.position.y),Time.deltaTime*(-GameObject.Find("Main Camera").transform.position.z-Target.transform.position.z)));

			//Vector3 endpos = new Vector3(Target.transform.position.x, 0, Target.transform.position.z);
			//newPos += Time.deltaTime * 0.003f;
			//GameObject.Find("Main Camera").transform.LookAt  
			//Translate (new Vector3(0.05f,0,0));
			//GameObject.Find("Main Camera").transform.position = Vector3.Lerp (GameObject.Find("Main Camera").transform.position, new Vector3(Target.transform.position.x, 0, Target.transform.position.z), newPos);
			//GameObject.Find ("Main Camera").transform.LookAt(testing, new Vector3(1,0,0));


			/*
			Vector3 playerpos = Vector3.zero;
			playerpos.x = testing.transform.position.x;
			playerpos.y = testing.transform.position.y;
			playerpos.z = testing.transform.position.z;
			Vector3 directionx = new Vector3 ((testing.transform.position.x - testing.transform.position.x), testing.transform.position.y - testing.transform.position.y, testing.transform.position.z - testing.transform.position.z);

			Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
			GameObject.Find("Main Camera").transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.05f* Time.time);
		*/

			//GameObject.Find("Main Camera").transform.rotation = Quaternion.RotateTowards(GameObject.Find("Main Camera").transform.rotation, testing.transform.rotation, 5f);





			//GameObject.Find ("Main Camera").transform.Translate (Vector3.forward); 
		
		}

	}

	void Start () {
		hello=1;
		Invoke ("RestartGame", 3.5f);
		whichway = gameObject.transform.position.z;
		//rb.AddExplosionForce(10,new Vector3 (0,0,0),5, 10);
	}
	// Update is called once per frame
	void RestartGame () {
		SceneManager.LoadScene ("main");
	}

}


