using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class sharebutton : MonoBehaviour {
	public Image share;
	//private bool isProcessing = false;
	public string mensaje;
	public GameObject selfadvertisement;
	public GameObject skip;
	public GameObject sharegraphics;
	public GameObject gemstonecount;
	public GameObject takeascreenshot;
	public GameObject revive;

	public void shareclicked (){
		share.enabled = false;
		selfadvertisement.SetActive (true);
		skip.SetActive (false);
		sharegraphics.SetActive (false);
		gemstonecount.SetActive (false);
		revive.SetActive (false);
		Invoke ("takeascreenshooooot", 0.1f);
		if (Application.platform == RuntimePlatform.Android) {
			StartCoroutine (takeScreenshotAndSave ());
		} else {
		}

	} 

	public void takeascreenshooooot () {
		takeascreenshot.SetActive (true);
	}


	private IEnumerator takeScreenshotAndSave()
	{
		string path = "";
		yield return new WaitForEndOfFrame();

		Texture2D screenImage = new Texture2D(Screen.width, Screen.height);

		//Get Image from screen
		screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		screenImage.Apply();

		//Convert to png
		byte[] imageBytes = screenImage.EncodeToPNG();


		System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/GameOverScreenShot");
		path = Application.persistentDataPath + "/GameOverScreenShot" + "/DiedScreenShot.png";
		System.IO.File.WriteAllBytes(path, imageBytes);

		StartCoroutine(shareScreenshot(path));
	}

	private IEnumerator shareScreenshot(string destination)
	{
		string ShareSubject = "Download Now";
		string shareLink = "Spacetrip!" + "\nBest Game Ever";
		string textToShare = "BestGameEver";

		Debug.Log(destination);


		if (!Application.isEditor)
		{
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);

			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "subject" + ShareSubject);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "hello" + textToShare);

			intentObject.Call<AndroidJavaObject>("setType", "image/png");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			currentActivity.Call("startActivity", intentObject);
		}
		yield return null;
	}

////break
	/*

		if(!isProcessing){
			StartCoroutine(ShareScreenshot() );
		}
	}
	public IEnumerator ShareScreenshot()
	{
		isProcessing = true;
		// wait for graphics to render
		yield return new WaitForEndOfFrame();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		// create the texture
		Texture2D screenTexture = new Texture2D(Screen.width, Screen.height,TextureFormat.RGB24,true);
		// put buffer into texture
		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
		// apply
		screenTexture.Apply();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		byte[] dataToSave = screenTexture.EncodeToPNG();
		string destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
		File.WriteAllBytes(destination, dataToSave);
		if(!Application.isEditor)
		{
			// block to open the file and share it ------------START
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

			intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), ""+ mensaje);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");

			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

			currentActivity.Call("startActivity", intentObject);
		}
		isProcessing = false;
		share.enabled = true;
	} */
}