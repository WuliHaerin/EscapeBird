


#define DISABLEADS  //COMMENT OUT THIS LINE IF YOU WANT TO ENABLE UNITY ADS
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

#if (!DISABLEADS)
public class AdManager : MonoBehaviour 
{
	

	public string gameID = "33675"; //33675 is test app from unity, please replace with your unity app id
	public bool testModeOn = false;
	public int awardAmount = 0; //how many diamonds to award player when he sees an add to the end
	public GameObject giftButton;

	void Awake()
	{
		Advertisement.Initialize (gameID, testModeOn);
	}

	public void ShowAd(string zone = "")
	{
		#if UNITY_EDITOR
		StartCoroutine(WaitForAd ());
		#endif

		if (string.Equals (zone, ""))
			zone = null;

		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;

		if (Advertisement.isReady())
			Advertisement.Show (zone, options);
	}

	public void Update() {

		if(Advertisement.IsReady()) {
			giftButton.GetComponent<Button>().enabled = true;
			giftButton.GetComponent<Image>().enabled = true;
		}
		else {
			giftButton.GetComponent<Button>().enabled = false;
			giftButton.GetComponent<Image>().enabled = false;
		}
	}


	void AdCallbackhandler (ShowResult result)
	{
		switch(result)
		{
		case ShowResult.Finished:
			
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopScript>().awardSweets(awardAmount);
			GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenuScript>().initMenu();//referesh the main menu
			break;
		case ShowResult.Skipped:

			break;
		case ShowResult.Failed:
			
			break;
		}
	}
	
	IEnumerator WaitForAd()
	{
		
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;

		while (Advertisement.isShowing)
			yield return null;

		Time.timeScale = currentTimeScale;
		
	}
}
#endif


