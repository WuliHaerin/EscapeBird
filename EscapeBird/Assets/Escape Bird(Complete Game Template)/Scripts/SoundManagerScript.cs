using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour {


	public   Image soundButton;
	public   Sprite soundOn;
	public   Sprite soundOff;


	//define the sounds for the game 
	public   AudioSource gameMusic;
	public   AudioSource gameOver;
	public  AudioSource hitSound;
	public  AudioSource clickSound;
	public  AudioSource rewardSound;

	private  int soundOnOff; // 1 is on 0 is off


	// Use this for initialization
	void Start () {
	
		playGameMusic();

		if( PlayerPrefs.HasKey("soundOnOff") ) {
		
			soundOnOff = PlayerPrefs.GetInt("soundOnOff");
		}
		else 
		{
			soundOnOff = 1;
		}
			
		setSoundButtonSprite();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public  void toggleSound() {
	
		switch(soundOnOff) {

		case 1: //on
			soundOnOff = 2;
			break;

		case 2: //off
			soundOnOff = 1;
			break;
		}

		setSoundButtonSprite();
		PlayerPrefs.SetInt("soundOnOff",soundOnOff);

	}
	private  void setSoundButtonSprite() {
	
		switch(soundOnOff) {

		case 1: //on
			soundButton.sprite = soundOn;
			AudioListener.volume = 1;
			break;

		case 2: //off
			soundButton.sprite = soundOff;
			AudioListener.volume = 0;
			break;
		}

	}

	public   void playGameMusic() {
	
		gameMusic.Play();
	}

	public  void playGameOver() {
	
		gameMusic.Stop();
		gameOver.Play();
	}

	public  void playHitSound() {
	
		hitSound.Play();
	}

	public  void playClickSound() {
	
		clickSound.Play();
	}
	public  void playAwardSound() {
	
		rewardSound.Play();
	}
}
