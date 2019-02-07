using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontdestroyload : MonoBehaviour {
	public Camera thecamera;


	public void click() {
		thecamera.backgroundColor = new Color (Random.value, Random.value, Random.value, 1);
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(LoadNewScene());
	}
		

	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator LoadNewScene() {

		yield return new WaitForSeconds(3);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = SceneManager.LoadSceneAsync(1);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			yield return null;
		}

	}

}
