using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

	public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if(coll.gameObject.tag == "box" || coll.gameObject.tag == "ground") {
		
			rb.isKinematic = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "upperlimit") {
		
			if(gameObject.GetComponent<Rigidbody2D>().isKinematic) {
				GameLoopScript gameLoop = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopScript>();
				gameLoop.moveCamera();
			}
	
		} 
	}
}
