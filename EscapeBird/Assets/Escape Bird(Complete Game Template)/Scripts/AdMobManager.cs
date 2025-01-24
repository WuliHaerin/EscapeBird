//#define DISABLEADMOB  //COMMENT OUT THIS LINE IF YOU WANT TO ENABLE ADMOB ADS
//using UnityEngine;
//using System.Collections;
//using GoogleMobileAds.Api;
//using UnityEngine.UI;

//#if (!DISABLEADMOB)
//public class AdMobManager : MonoBehaviour {

//	public string androidAdUnit = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
//	public string iosAdUnit = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
//	public int awardAmount = 0; //how many diamonds to award player when he sees an add to the end
//	private RewardBasedVideoAd rewardBasedVideo;
//	private bool rewardBasedEventHandlersSet = false;
//	public GameObject giftButton;
//	// Use this for initialization
//	void Start () {
	
//		RequestVideoAd();
//	}
	
//	// Update is called once per frame
//	public void Update() {

//		if(rewardBasedVideo.IsLoaded()) {
//			giftButton.GetComponent<Button>().enabled = true;
//			giftButton.GetComponent<Image>().enabled = true;
//		}
//		else {
//			giftButton.GetComponent<Button>().enabled = false;
//			giftButton.GetComponent<Image>().enabled = false;
//		}
//	}

//	private void RequestVideoAd()
//	{
//		#if UNITY_EDITOR
//		string adUnitId = "unused";
//		#elif UNITY_ANDROID
//		string adUnitId = androidAdUnit;
//		#elif UNITY_IPHONE
//		string adUnitId = iosAdUnit;
//		#else
//		string adUnitId = "unexpected_platform";
//		#endif

//		rewardBasedVideo = RewardBasedVideoAd.Instance;

//		AdRequest request = new AdRequest.Builder().Build();
//		rewardBasedVideo.LoadAd(request, adUnitId);

//		if (!rewardBasedEventHandlersSet)
//		{
//		// Ad event fired when the rewarded video ad
//		// has been received.
//		//rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
//		// has failed to load.
//		//rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
//		// is opened.
//		//rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
//		// has started playing.
//		//rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
//		// has rewarded the user.
//		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
//		// is closed.
//		//rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
//		// is leaving the application.
//		//rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

//		rewardBasedEventHandlersSet = true;
//		}

//		}


//	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
//	{

//		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopScript>().awardSweets(awardAmount);
//		GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenuScript>().initMenu();//referesh the main menu
//	}

	
//	public  void showAd()
//	{
//		if (rewardBasedVideo.IsLoaded()) {
//			rewardBasedVideo.Show();
//			RequestVideoAd(); //request another ad for next time
//		}
//	}


//}
//#endif