using UnityEngine;
using System.Collections;

public class GameLoopScript : MonoBehaviour {

	public GameObject[] spawners;
	public GameObject[] spawners_explanationMarks;
	public Sprite explanationMark;
	public int MaxBoxToSpwan = 3;
	public GameObject box;
	public GameObject candy;
	public float spawnCandyEvery = 30f; //seconds
	public bool gameOver = true;
	MenuManagerScript menuManager;
	TimerScript timer;
	public GameObject[] birds;
	public BirdController curBird;
	public GameObject mainCamera;
	public ControlButtonsScript controlButton;
	private Vector3 targetPosition;
	private Vector3 cameraMoveVelocity = Vector3.zero;
	public GameObject AdPanel;
	public GameObject CandyAdPanel;
	public bool isCancelAd;

	// Use this for initialization
	void Start () {
	
		menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManagerScript>();
		timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();
		InvokeRepeating("doSpawnBoxes",3f,5f);
		InvokeRepeating("dropCandy",spawnCandyEvery,spawnCandyEvery);
	}
	
	public void SetAdPanel(bool a)
    {
		AdPanel.SetActive(a);
		Time.timeScale = a ? 0 : 1;
    }

	public void Revive()
    {
		GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>().Revive();
    }

	public void CancelAd()
    {
		isCancelAd = true;
		SetAdPanel(false);
    }

	// Update is called once per frame
	void Update () {


		if(gameOver)
			return;

		if(targetPosition.y != mainCamera.transform.position.y)
			doMoveCamera();

	}

	public void doSpawnBoxes() {
	
		int howManyBoxes = 0; 
		if(gameOver)
			return;

		howManyBoxes = Random.Range(1,MaxBoxToSpwan+1);

		spawnBox(howManyBoxes);
	}

	public void spawnBox(int howMany) {
	
		int[] spawnLocations;
		int   spawnLocation;
		bool  found = false;
		spawnLocations = new int[howMany];

		spawnLocation = Random.Range(0,8);
		spawnLocations[0] = spawnLocation;

		if(howMany > 1)
		for(int i = 1; i < howMany; i++) {

			found = false;
			while(!found) {
			
				spawnLocation = Random.Range(0,8); 
				found = true;
				foreach(int temp in spawnLocations) {
					
					if(temp == spawnLocation) {
						found = false;
					}
				}
			}
			spawnLocations[i] = spawnLocation;
		}

		foreach(int temp in spawnLocations) {

			spawners_explanationMarks[temp].GetComponent<SpriteRenderer>().sprite = explanationMark;

		}

		//drop boxes and hide explanation marks
		StartCoroutine(dropBoxes(spawnLocations));

	}

	IEnumerator dropBoxes(int[] locations) {
		
		yield return new WaitForSeconds(2);
		foreach(int temp in locations) {

			spawners_explanationMarks[temp].GetComponent<SpriteRenderer>().sprite = null;
			Instantiate(box,spawners_explanationMarks[temp].transform.position,
				Quaternion.identity);
		}

	}

	public void dropCandy() {
	
		if(gameOver)
			return;
		
		int spawnLocation = Random.Range(0,8);
		Instantiate(candy,spawners_explanationMarks[spawnLocation].transform.position,
			Quaternion.identity);


	}


	public void moveCamera() {
	
		if(gameOver)
			return;
		
		targetPosition = mainCamera.transform.position;
		targetPosition.y = targetPosition.y + 3f; //move camera to clear the scene from boxes
	}


	void doMoveCamera() {

		mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPosition, ref cameraMoveVelocity, 0.3f);

	}

	public void refreshScene() {
	
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("box")) {

			Destroy(obj);
		}
	}

	public void startNewGame() {
	
		gameOver = false;
		menuManager.showControlAndHUDMenu();
		timer.resetTime(0,0);
		timer.startTimer();
		isCancelAd = false;
	}

	public void doGameOver() {
	
		gameOver = true;
		timer.stopTimer();

		//destory all boxes
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("box")) {
		
			Destroy(obj);
		}
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("candy")) {

			Destroy(obj);
		}
		//respawn the bird
		respawnBird();


		mainCamera.transform.position = new Vector3(0,0,-10);
		targetPosition = mainCamera.transform.position;
		menuManager.showMainMenu();



	}

	public void respawnBird() {
	
		GameObject playerObj;
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Player")) {

			Destroy(obj);
		}
			
		playerObj =  Instantiate(birds[PlayerSettings.getSelectedBird()],new Vector3(0f,0f,0f),
			Quaternion.identity) as GameObject;

		controlButton.birdController = playerObj.GetComponent<BirdController>();

	}

	public void awardSweets(int amount) {
	
		PlayerSettings.setCandy((PlayerSettings.getCandy() + amount));

	}
}
