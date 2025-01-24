using UnityEngine;
using System.Collections;

public class ChangeThemeScript : MonoBehaviour {

	GameLoopScript gameLoop;

	public int numberOfThemes = 2;
	public GameObject[] sweetsSprite;
	public GameObject[] sweetsNumber;
	public GameObject[] themes;
	ChangeBirdOrTheme changeBirdOrTheme = new ChangeBirdOrTheme();
	// Use this for initialization
	void Start () {

		initMenu();
		gameLoop = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopScript>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void changeThemeAction(string bird) {

		int themeNo = int.Parse(bird);

		switch(themeNo) {

		case 0:
			changeBirdOrTheme.changeBirdOrTheme(ChangeBirdOrTheme.CHANGE_THEME,themeNo,0);
			if(PlayerSettings.isThemeUnlocked(themeNo)) {

				gameLoop.respawnBird();
				initMenu();

				for(int i = 0;i < themes.Length;i++) {

					if(themeNo == i)
						themes[i].SetActive(true);
					else
						themes[i].SetActive(false);
				}
			}
			break;

		case 1: 
			changeBirdOrTheme.changeBirdOrTheme(ChangeBirdOrTheme.CHANGE_THEME,themeNo,10);
			if(PlayerSettings.isThemeUnlocked(themeNo)) {
			
				gameLoop.respawnBird();
				initMenu();

				for(int i = 0;i < themes.Length;i++) {

					if(themeNo == i)
						themes[i].SetActive(true);
					else
						themes[i].SetActive(false);
				}
			}
			break;
		}
	}


	public void initMenu() {

		//check if theme is already unlocked then do not show the sweets required for the theme

		for(int i = 0; i < numberOfThemes;i++) {

			if(PlayerSettings.isThemeUnlocked(i)) {

				sweetsNumber[i].SetActive(false);
				sweetsSprite[i].SetActive(false);
			}
		}
	}
}
