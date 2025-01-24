using UnityEngine;
using System.Collections;

public class PlayerSettings : MonoBehaviour {

	public  enum Birds {Bird1,Bird2};
	public static Birds availableBirds;
	public  enum Themes {Summer,Winter};
	public static Themes availableThemes;
	public static string birdKey = "bird";
	public static string themeKey = "theme";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void setCandy(int candyCount) {
	
		PlayerPrefs.SetInt("candyCount",candyCount);
		PlayerPrefs.Save();

	}

	public static int getCandy() {
	
		if(PlayerPrefs.HasKey("candyCount")) {
		
			return PlayerPrefs.GetInt("candyCount");
		}
		else {
		
			return 0;
		}
	}

	public static void setSelectedBird(int birdNo) {
	
		PlayerPrefs.SetInt("myBird",birdNo);
	}
	public static int getSelectedBird() {

		if(PlayerPrefs.HasKey("myBird")) {
		
			return PlayerPrefs.GetInt("myBird");
		}
		else {
		
			return (int) Birds.Bird1; //default is the first bird
		}
	}

	public static void unlockBird(int birdNo) {

		string key = birdKey + birdNo; 
		PlayerPrefs.SetInt(key,1);
	}

	public static bool isBirdUnlocked(int birdNo) {

		if(birdNo == 0) //first bird is always unlocked
			return true;
		
		string key = birdKey + birdNo; 
		if(PlayerPrefs.HasKey(key))
			return true;

		return false;
	}

	public static void storTime(string theTime) {
	
		PlayerPrefs.SetString("myTime",theTime);
	}

	public static string getTime() {

		if(PlayerPrefs.HasKey("myTime"))
			return PlayerPrefs.GetString("myTime");
		else
			return "00:00";
	}


	//theme
	public static void setSelectedTheme(int themeNo) {

		PlayerPrefs.SetInt("myTheme",themeNo);
	}

	public static int getSelectedTheme() {

		if(PlayerPrefs.HasKey("myTheme")) {

			return PlayerPrefs.GetInt("myTheme");
		}
		else {

			return (int) Themes.Summer; //default is the first summer theme
		}
	}

	public static void unlockTheme(int themeNo) {

		string key = themeKey + themeNo; 
		PlayerPrefs.SetInt(key,1);
	}

	public static bool isThemeUnlocked(int themeNo) {

		if(themeNo == 0) //first bird is always unlocked
			return true;

		string key = themeKey + themeNo; 
		if(PlayerPrefs.HasKey(key))
			return true;

		return false;
	}

}
