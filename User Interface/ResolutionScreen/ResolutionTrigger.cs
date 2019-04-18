using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionTrigger : MonoBehaviour {

	public GameObject ResolutionScreen;
	public GameObject NonDiegeticUI;
	public Statistics playerStatistics;

	void Start () {
		ResolutionScreen.SetActive(false);
		GameOverEvent.Register(onGameOver);
	}

	void onGameOver(GameOverEvent gameOver)
	{
		NonDiegeticUI.SetActive(false);
		playerStatistics.SetIsCompleted(gameOver.IsCompleted);
		ResolutionScreen.SetActive(true);
		ResolutionScreen.GetComponentInChildren<ResolutionSetup>().SetUpResolutionScreen();
	}
}
