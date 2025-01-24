using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	public Text sweetsNo;
	public Text myTime;
	// Use this for initialization
	void Start () {

		initMenu();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initMenu() {
	
		sweetsNo.text = PlayerSettings.getCandy().ToString();
		myTime.text = PlayerSettings.getTime();
	}
}
