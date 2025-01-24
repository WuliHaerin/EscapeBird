using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	
	public Text guiTimeText;
	public int gameTimeMinutes = 0;
	public int gameTimeSeconds = -1;
	public bool countUp = false;

	private float startTime;
	private int lastSeconds = 0;

	// Use this for initialization
	void Start () {

		startTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(countUp) {
			updateGUITime();
		}
	}
	

	void updateGUITime() {
		
		float guiTime = Time.time - startTime;
		int minutes;
		int seconds;
		int fraction;
		
		minutes = (int) guiTime / 60;
		seconds = (int) guiTime % 60;
		fraction = (int) (guiTime * 100) % 100;


		if(seconds > lastSeconds) {

			lastSeconds = seconds;
			gameTimeSeconds++;
		}

		if(seconds < lastSeconds) {
			
			lastSeconds = 0;
			gameTimeSeconds++;
		}
			

		if(gameTimeSeconds > 59) {
			
			gameTimeMinutes++;
			gameTimeSeconds = 0;
		}

		guiTimeText.text = string.Format("{0:00}:{1:00}", gameTimeMinutes, gameTimeSeconds);

	}

	public void resetTime(int minutes,int seconds) {
	
		gameTimeMinutes = 0;
		gameTimeSeconds = 0;
	}

	public void reloadTime() {
	
		//gameTimeMinutes = PlayerPrefTracker.getSavedMinutes();
		//gameTimeSeconds = PlayerPrefTracker.getSavedSeconds();

		guiTimeText.text = string.Format("{0:00}:{1:00}", gameTimeMinutes, gameTimeSeconds);

	}

	public void saveTimer() {
	
		//PlayerPrefTracker.saveTime(gameTimeMinutes,gameTimeSeconds);
	}

	public void startTimer() {

		startTime = Time.time;
		countUp = true;
	}

	public void stopTimer() {
		countUp = false;
		PlayerSettings.storTime(guiTimeText.text);
	}

}
