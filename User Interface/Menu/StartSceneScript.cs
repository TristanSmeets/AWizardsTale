using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneScript : MonoBehaviour {

	public GameObject LoadingScreen;
	public GameObject EventSystem;

	public void StartScene(string sceneName)
	{
		EventSystem.SetActive(false);
		Instantiate(LoadingScreen).GetComponentInChildren<LoadingSceneScript>().LoadLevel(sceneName);
		Time.timeScale = 1;
	}

	public void StartSceneButtonActivation(string sceneName)
	{
		EventSystem.SetActive(false);
		Instantiate(LoadingScreen).GetComponentInChildren<LoadingScreenButtonActivation>().LoadSceneButtonActivation(sceneName);
	}
}
