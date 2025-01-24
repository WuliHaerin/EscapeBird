using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	public static int FACE_RIGHT = 1;
	public static int FACE_LEFT = 2;
	private bool miss;

	public Rigidbody2D myRB;

	private bool hitBoxLeftSide = false;
	private bool hitBoxRightSide = false;
	public  float sideForceAmount = 10f;
	public  float upForceAmount = 10f;
	private float sideForce;
	private float upForce;
	private int myDirection;
	private bool goRight = false;
	private bool goLeft = false;
	public Animator myAnimator;
	GameLoopScript gameLoop;
	SoundManagerScript soundManager;
	// Use this for initialization
	void Start () {
	
		gameLoop = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopScript>();
		soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(gameLoop.gameOver) 
			return; //if game is over do not control the bird
		
		sideForce = 0;
		upForce = 0;
		//previousX = this.transform.position.x;
		if((Input.GetKey("left") || goLeft) && (!hitBoxRightSide)) {

			sideForce = -sideForceAmount;
		}

		if((Input.GetKey("right") || goRight) && (!hitBoxLeftSide)) {

			sideForce = sideForceAmount;
		}


		if(hitBoxRightSide && (Input.GetKey("left") || goLeft)) {
		
			upForce = upForceAmount;
		}

		if(hitBoxLeftSide && (Input.GetKey("right") || goRight)) {

				upForce = upForceAmount;
			}
			
		//check animation state 
		if(upForce != 0 || sideForce != 0) {
		
			myAnimator.SetBool("sleeping",false);
			myAnimator.SetBool("run",true);
		}
		else {
		
			myAnimator.SetBool("run",false);
		}
		//change player direction

		if((Input.GetKey("right") || goRight) && myDirection != FACE_RIGHT) {
			myDirection = FACE_RIGHT;
			flipBirdDirection(FACE_RIGHT);
		}
		if((Input.GetKey("left") || goLeft) && myDirection != FACE_LEFT) {
			myDirection = FACE_LEFT;
			flipBirdDirection(FACE_LEFT);
		}
		myRB.AddForce(new Vector2(sideForce,upForce));
	}

	public IEnumerator Die()
	{
		yield return new WaitForSeconds(0.3f);
		if(gameLoop.isCancelAd)
        {
			gameLoop.doGameOver();
			soundManager.playHitSound();
			Destroy(gameObject);
		}
	}

	public void Revive()
    {
		AdManager.ShowVideoAd("192if3b93qo6991ed0",
		   (bol) => {
			   if (bol)
			   {
				   transform.position = new Vector3(0, 0, 0);
				   gameLoop.SetAdPanel(false);
				   StopCoroutine(Die());
				   StartCoroutine(Miss());

				   AdManager.clickid = "";
				   AdManager.getClickid();
				   AdManager.apiSend("game_addiction", AdManager.clickid);
				   AdManager.apiSend("lt_roi", AdManager.clickid);


			   }
			   else
			   {
				   StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
			   }
		   },
		   (it, str) => {
			   Debug.LogError("Error->" + str);
				//AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
			});
	}

	public IEnumerator Miss()
    {
		miss = true;
		yield return new WaitForSeconds(1f);
		miss = false;
    }
	
	void OnTriggerEnter2D(Collider2D other) {

		if(other.tag == "boxLeftSide") {
		
			hitBoxLeftSide = true;
		}

		if(other.tag == "boxRightSide") {

			hitBoxRightSide = true;
		}

		if(other.tag == "boxBottomSide") {

			//if(other.gameObject.GetComponentInParent<Rigidbody2D>().isKinematic)
			//	return; //this is a false trigger do not do anything
			//this.gameObject.SetActive(false);
			if(!miss)
            {
				if (!gameLoop.isCancelAd)
				{
					gameLoop.SetAdPanel(true);
					StartCoroutine(Die());
				}
				else
				{
					StartCoroutine(Die());
				}
			}
			
		}

		

		if(other.tag == "candy") {

			//give the player some candy points here
			Destroy(other.gameObject);
			PlayerSettings.setCandy((PlayerSettings.getCandy() + 1));
			soundManager.playAwardSound();
		}
			
	}

	void OnTriggerStay2D(Collider2D other) {

		if(other.tag == "boxLeftSide") {

			hitBoxLeftSide = true;
		}

		if(other.tag == "boxRightSide") {

			hitBoxRightSide = true;
		}
	}


	void OnTriggerExit2D(Collider2D other) {

		if(other.tag == "boxLeftSide") {

			hitBoxLeftSide = false;
		}

		if(other.tag == "boxRightSide") {

			hitBoxRightSide = false;
		}
	}
		
	private void flipBirdDirection(int direction) {
	
		Vector3 myScale;
		if(direction == FACE_RIGHT) {
		
			myScale = transform.localScale;
			myScale.x = -myScale.x;
			transform.localScale = myScale;
		}
		else {
		
			myScale = transform.localScale;
			myScale.x = Mathf.Abs(myScale.x);
			transform.localScale = myScale;

		}
	}

	public void doGoLeft() {
	
		goLeft = true;
	}
	public void stopDoGoLeft() {
	
		goLeft = false;
	}

	public void doGoRight() {

		goRight = true;
	}
	public void stopDoGoRight() {

		goRight = false;
	}


}
