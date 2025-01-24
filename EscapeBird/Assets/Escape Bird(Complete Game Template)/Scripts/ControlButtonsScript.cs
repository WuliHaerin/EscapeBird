using UnityEngine;
using System.Collections;

public class ControlButtonsScript : MonoBehaviour {

	public BirdController birdController;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goRight () {

		birdController.doGoRight();
	}

	public void goLeft () {

		birdController.doGoLeft();
	}

	public void stopGoRight () {

		birdController.stopDoGoRight();
	}

	public void stopGoLeft () {

		birdController.stopDoGoLeft();
	}


}
