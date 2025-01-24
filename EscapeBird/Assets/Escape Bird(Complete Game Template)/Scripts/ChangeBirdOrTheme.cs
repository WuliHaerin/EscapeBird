using UnityEngine;
using System.Collections;

public class ChangeBirdOrTheme : MonoBehaviour
{

	public const int CHANGE_BIRD = 1;
	public const int CHANGE_THEME = 2;
	public GameObject CandyAdPanel;
	GameLoopScript gameLoop;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void changeBirdOrTheme(int birdOrTheme, int number, int requiredCandy)
	{
		gameLoop = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLoopScript>();
		CandyAdPanel = gameLoop.CandyAdPanel;
		switch (birdOrTheme)
		{

			case CHANGE_BIRD:
				//first check if player has unlocked this bird already
				if (PlayerSettings.isBirdUnlocked(number))
				{

					//yes bird unlocked set player bird
					PlayerSettings.setSelectedBird(number);
				}
				else
				{

					//no then check if player can unlock this bird and use it in the game
					if (PlayerSettings.getCandy() >= requiredCandy)
					{

						PlayerSettings.unlockBird(number);
						PlayerSettings.setCandy(PlayerSettings.getCandy() - requiredCandy);
						PlayerSettings.setSelectedBird(number);
					}
					else
					{
						CandyAdPanel.SetActive(true);
					}
				}
				break;

			case CHANGE_THEME:

				//first check if player has unlocked this theme already
				if (PlayerSettings.isThemeUnlocked(number))
				{

					//yes bird unlocked set player bird
					PlayerSettings.setSelectedTheme(number);
				}
				else
				{

					//no then check if player can unlock this bird and use it in the game
					if (PlayerSettings.getCandy() >= requiredCandy)
					{

						PlayerSettings.unlockTheme(number);
						PlayerSettings.setCandy(PlayerSettings.getCandy() - requiredCandy);
						PlayerSettings.setSelectedTheme(number);
					}
                    {
						CandyAdPanel.SetActive(true);
					}
				}

				break;
		}
	}
}
