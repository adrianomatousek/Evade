using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;
using UnityEngine.SceneManagement;
 
public class AdManager : MonoBehaviour {
	
	public static AdManager	Instance { set; get;}
	public string appID = "ca-app-pub-5652960355591858~8231289922";
	public string videoID = "ca-app-pub-5652960355591858/2184756326";
	public string bannerID = "ca-app-pub-5652960355591858/4440218728";
	public string rewardvideoID = "ca-app-pub-5652960355591858/4623518721";
	public static int ReviveWatched;

	private void Start() {
		Admob.Instance().rewardedVideoEventHandler += AdManager_rewardedVideoEventHandler;
		Instance = this;
		DontDestroyOnLoad (gameObject);
		if (Application.platform != RuntimePlatform.WindowsEditor) {
			Admob.Instance ().initAdmob (bannerID, videoID);
			//Admob.Instance ().setTesting (true);
			Admob.Instance ().loadInterstitial ();
			//Admob.Instance ().setTesting (true);
			Admob.Instance ().loadRewardedVideo (rewardvideoID);
		}
	}

	public void ShowBanner () {
		if (Application.platform != RuntimePlatform.WindowsEditor) {
			Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
		}
	}

	public void ShowVideo () {
		if (Application.platform != RuntimePlatform.WindowsEditor) {
			if (Admob.Instance ().isInterstitialReady ()) {
				Admob.Instance ().showInterstitial ();
				Invoke ("loadInterstitial", 1);
			} else {
				Admob.Instance ().loadInterstitial ();
			}
		}
	}

	public void ShowRewardVideo () {
		print ("showing reward");
		if (Admob.Instance ().isRewardedVideoReady ()) {
			Admob.Instance ().showRewardedVideo ();
			print ("video is ready");
		} else {
			Admob.Instance ().loadRewardedVideo (rewardvideoID);
			print ("loading video");
		}
	}

	public void ReviveVideo () {
		print ("showing reward revive");
		if (Admob.Instance ().isRewardedVideoReady ()) {
			Admob.Instance ().showRewardedVideo ();
			print ("video is ready");
		} else {
			Admob.Instance ().loadRewardedVideo (rewardvideoID);
			print ("loading video");
		}
	}


	public void HideAds () {
		Admob.Instance ().removeAllBanner();
	}

	void onRewardedVideoEvent(string eventName, string msg)
	{
		
		Debug.Log("handler onRewardedVideoEvent---" + eventName + "   " + msg);
		//PlayerPrefs.SetInt ("gemstonenumber", PlayerPrefs.GetInt ("gemstonenumber") + 10);

	}



	private void AdManager_rewardedVideoEventHandler(string eventName, string msg)
	{
		if (eventName == AdmobEvent.onRewarded)
		{
			Debug.Log("Rewarding player...rewarded count"+msg);
			PlayerPrefs.SetInt ("gemstonenumber", PlayerPrefs.GetInt ("gemstonenumber") + 10);
			Admob.Instance ().loadRewardedVideo (rewardvideoID);
			SpinningCube.watchedrewardvideo += 1;
			if (ReviveWatched == 1) {
				PlayerPrefs.SetInt ("revive", 1);
				ReviveWatched = 0;
				SceneManager.LoadScene ("main");
			}
		}
		Debug.Log("Event: "+eventName);
	}


	public void loadInterstitial() {
		Admob.Instance ().loadInterstitial ();
	}



}
