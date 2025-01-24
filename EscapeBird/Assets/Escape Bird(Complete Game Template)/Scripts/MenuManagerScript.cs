using UnityEngine;
using System.Collections;

public class MenuManagerScript : MonoBehaviour {

	public Canvas mainMenu;
	public Canvas birdSelectMenu;
	public Canvas themeSelectMenu;
	public Canvas controlButtons;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showBirdSelectMenu() {

		mainMenu.enabled = false;
		birdSelectMenu.enabled = true;
		themeSelectMenu.enabled = false;
		controlButtons.enabled = false;
	}

	public void showMainMenu() {

		mainMenu.enabled = true;
		birdSelectMenu.enabled = false;
		themeSelectMenu.enabled = false;
		controlButtons.enabled = false;
		mainMenu.gameObject.GetComponent<MainMenuScript>().initMenu();
	}

	public void showThemeMenu() {

		mainMenu.enabled = false;
		birdSelectMenu.enabled = false;
		themeSelectMenu.enabled = true;
		controlButtons.enabled = false;
	}

	public void showControlAndHUDMenu() {

		mainMenu.enabled = false;
		birdSelectMenu.enabled = false;
		themeSelectMenu.enabled = false;
		controlButtons.enabled = true;
	}
}
