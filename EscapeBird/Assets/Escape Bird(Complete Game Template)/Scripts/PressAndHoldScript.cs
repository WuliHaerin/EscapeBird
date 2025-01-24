using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class PressAndHoldScript : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

	public enum myType{leftButton,rightButton};
	public myType buttonType;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//this method is used to simulate the pressing and holding on the screen for the shoot button
	//the shoot button is invisible button under the gameHUD game object prefab
	public void OnPointerDown( PointerEventData eventData ) {

		if(buttonType == myType.rightButton) {
		GameObject.FindGameObjectWithTag("controlButtons").GetComponent<ControlButtonsScript>().goRight();
		}

		if(buttonType == myType.leftButton) {
			GameObject.FindGameObjectWithTag("controlButtons").GetComponent<ControlButtonsScript>().goLeft();
		}

	}

	public void OnPointerUp( PointerEventData eventData ) {

		if(buttonType == myType.rightButton) {
			GameObject.FindGameObjectWithTag("controlButtons").GetComponent<ControlButtonsScript>().stopGoRight();
		}

		if(buttonType == myType.leftButton) {
			GameObject.FindGameObjectWithTag("controlButtons").GetComponent<ControlButtonsScript>().stopGoLeft();
		}

	}


	public void OnPointerExit( PointerEventData eventData ) {

	}
}
