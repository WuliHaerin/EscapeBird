using UnityEngine;
using System.Collections;

public class ChangeBirdScript : MonoBehaviour {

	GameLoopScript gameLoop;

	public int numberOfBirds = 2;
	public GameObject[] sweetsSprite;
	public GameObject[] sweetsNumber;
	ChangeBirdOrTheme changeBirdOrTheme = new ChangeBirdOrTheme();
	// Use this for initialization
	void Start () {

		initMenu();
		gameLoop = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeBirdAction(string bird) {

		int birdNo = int.Parse(bird);

		switch(birdNo) {

		case 0:
			changeBirdOrTheme.changeBirdOrTheme(ChangeBirdOrTheme.CHANGE_BIRD,birdNo,0);
			gameLoop.respawnBird();
			initMenu();
			break;

		case 1: 
			changeBirdOrTheme.changeBirdOrTheme(ChangeBirdOrTheme.CHANGE_BIRD,birdNo,10);
			gameLoop.respawnBird();
			initMenu();
			break;
		}
	}
		

	public void initMenu() {
	
		//check if bird is already unlocked then do not show the sweets required for the bird

		for(int i = 0; i < numberOfBirds;i++) {
		
			if(PlayerSettings.isBirdUnlocked(i)) {
			
				sweetsNumber[i].SetActive(false);
				sweetsSprite[i].SetActive(false);
			}
		}
	}
}
