using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenTrigger : MonoBehaviour {
	public GameObject PauseScreen;
	public Keybindings keys;
	public Statistics playerStats;
	public GameObject NonDiegetic;
	public Text CrystalText;

	int totalFragments;
	float previous = 0;

	void Start () {
		PauseScreen.SetActive(false);
		totalFragments = GameObject.FindGameObjectsWithTag("CrystalFragment").Length;
	}
	
	void Update () {
		if (InputWrapper.GetEscape(keys) > 0 && previous <= 0.001f)
		{
			changePauseScreenActive(!PauseScreen.activeSelf);
			updateText();
		}
		previous = InputWrapper.GetEscape(keys);
	}

	public void TurnOffPauseScreen()
	{
		changePauseScreenActive(false);
	}

	void changePauseScreenActive(bool value)
	{
		Cursor.visible = value;
		PauseScreen.SetActive(value);
		NonDiegetic.SetActive(!value);

		if (value)
		{
			Cursor.lockState = CursorLockMode.Confined;
			Time.timeScale = 0;
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1;
		}
	}

	void updateText()
	{
		CrystalText.text = string.Format("{0}/{1}", playerStats.GetFragmentsCollected(), totalFragments);
	}
}
