using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenButtonActivation : MonoBehaviour {

	public Text LoadingText;
	
	public void LoadSceneButtonActivation(string sceneName)
	{
		StartCoroutine(LoadSceneAsyncButtonActivation(sceneName));
		GetComponent<LoadingScreenAnimation>().PlayBlinkingAnimation();
	}

	IEnumerator LoadSceneAsyncButtonActivation(string sceneName)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
		asyncLoad.allowSceneActivation = false;

		while (!asyncLoad.isDone)
		{
			LoadingText.text = string.Format("Loading progress: {0}%", (int)asyncLoad.progress);

			if (asyncLoad.progress >= 0.9f)
			{
				LoadingText.text = "Press 'Enter' to continue";

				if (Input.GetKeyDown(KeyCode.Return))
					asyncLoad.allowSceneActivation = true;
			}
			yield return null;
		}
		GetComponent<LoadingScreenAnimation>().PlayFadeOutAnimation();
	}
}
