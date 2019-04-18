using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSetup : MonoBehaviour {
	public Statistics statistics;

	public Text ResolutionText;
	public Text ScoreText;
	public Text FragmentText;

	public string VictoryText;
	public string LosingText;

	public void SetUpResolutionScreen()
	{
		//Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		ResolutionText.text = setResolutionText(statistics.GetIsCompleted());
		ScoreText.text = string.Format("{0}", statistics.GetEnemiesKilled());
		FragmentText.text = string.Format("{0}", statistics.GetFragmentsCollected());
	}

	string setResolutionText(bool isCompleted)
	{
		if (isCompleted)
			return VictoryText;
		return LosingText;
	}

}
