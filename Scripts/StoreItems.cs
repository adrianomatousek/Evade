using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreItems : MonoBehaviour {
	public GameObject ScrollShips;
	public GameObject ScrollScenes;
	public GameObject ScrollMusic;
	public GameObject ScrollGems;
	public int SelectedMenu;
	public Vector3 visibleposition;
	public Vector3 hiddenposition;


	// Use this for initialization
	void Start () {
		QualitySettings.SetQualityLevel (4, true);
		Time.timeScale = 1;
		SelectedMenu = 0;
		visibleposition = new Vector3 (-0.00096731f, -111.44f, 0f);
		hiddenposition = new Vector3 (-0.00096731f, -211.44f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (SelectedMenu == 0) {
			ScrollShips.transform.localPosition = Vector3.Lerp(ScrollShips.transform.localPosition, visibleposition, 2f*Time.deltaTime);
			ScrollScenes.transform.localPosition = Vector3.Lerp(ScrollScenes.transform.localPosition, hiddenposition, 2f*Time.deltaTime);
			ScrollMusic.transform.localPosition = Vector3.Lerp(ScrollMusic.transform.localPosition, hiddenposition, 2f*Time.deltaTime);
			ScrollGems.transform.localPosition = Vector3.Lerp(ScrollGems.transform.localPosition, hiddenposition, 2f*Time.deltaTime);

		}
		if (SelectedMenu == 1) {
			ScrollShips.transform.localPosition = Vector3.Lerp(ScrollShips.transform.localPosition, hiddenposition, 2f*Time.deltaTime);
			ScrollScenes.transform.localPosition = Vector3.Lerp(ScrollScenes.transform.localPosition, visibleposition, 2f*Time.deltaTime);
			ScrollMusic.transform.localPosition = Vector3.Lerp(ScrollMusic.transform.localPosition, hiddenposition, 2f*Time.deltaTime);
			ScrollGems.transform.localPosition = Vector3.Lerp(ScrollGems.transform.localPosition, hiddenposition, 2f*Time.deltaTime);

		}
		if (SelectedMenu == 2) {
			ScrollShips.transform.localPosition = Vector3.Lerp(ScrollShips.transform.localPosition, hiddenposition, 2f*Time.deltaTime);
			ScrollScenes.transform.localPosition = Vector3.Lerp(ScrollScenes.transform.localPosition, hiddenposition, 2f*Time.deltaTime);
			ScrollMusic.transform.localPosition = Vector3.Lerp(ScrollMusic.transform.localPosition, visibleposition, 2f*Time.deltaTime);
			ScrollGems.transform.localPosition = Vector3.Lerp(ScrollGems.transform.localPosition, hiddenposition, 2f*Time.deltaTime);

		}
		if (SelectedMenu == 3) {
			ScrollShips.transform.localPosition = Vector3.Lerp(ScrollShips.transform.localPosition, hiddenposition, 2f*Time.deltaTime);
			ScrollScenes.transform.localPosition = Vector3.Lerp(ScrollScenes.transform.localPosition, hiddenposition, 2f*Time.deltaTime);
			ScrollMusic.transform.localPosition = Vector3.Lerp(ScrollMusic.transform.localPosition, hiddenposition, 2f*Time.deltaTime);
			ScrollGems.transform.localPosition = Vector3.Lerp(ScrollGems.transform.localPosition, visibleposition, 2f*Time.deltaTime);
		}
	}


	public void test () {
		print ("test");
	}

	public void ShipsMenu () {
		SelectedMenu = 0;
	}

	public void ScenesMenu () {
		SelectedMenu = 1;
	}

	public void MusicMenu () {
		SelectedMenu = 2;
	}

	public void GemsMenu () {
		SelectedMenu = 3;
	}

	public void Back () {
		SceneManager.LoadScene ("LoadScreen");
	}

}
