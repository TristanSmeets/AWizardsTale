using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneScript : MonoBehaviour
{
	public float LoadScreenTime;
	float counter;
	bool isCountingDown = false;
	bool fadeIn = false;
	string sceneName;
	Image bg;
	private void Start()
	{
		counter = LoadScreenTime;
		DontDestroyOnLoad(gameObject.transform.parent.gameObject);
		bg = GetComponent<Image> ();
	}

	private void Update()
	{
		if (isCountingDown && !fadeIn) {
			bg.color = new Color (bg.color.r, bg.color.g, bg.color.b, Mathf.Clamp01 (1 - counter));
			counter -= Time.deltaTime;
		}

		if (isCountingDown && fadeIn) {
			bg.color = new Color (bg.color.r, bg.color.g, bg.color.b, Mathf.Clamp01 (counter));
			counter -= Time.deltaTime;
		}

		if (counter < 0 && isCountingDown)
		{
			if (fadeIn) {
				Destroy (gameObject);
				return;
			}
			StartCoroutine(LoadSceneAsyncTimedActivation(sceneName));
			isCountingDown = false;
			counter = LoadScreenTime;
		}
	}

	public void LoadLevel(string sceneName)
	{
		this.sceneName = sceneName;

		GetComponent<LoadingScreenAnimation>().PlayBlinkingAnimation();
		isCountingDown = true;
	}

	IEnumerator LoadSceneAsyncTimedActivation(string sceneName)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

		while (!asyncLoad.isDone)
		{
			yield return null;
		}

		GetComponent<LoadingScreenAnimation>().PlayFadeOutAnimation();
		FadeOutBG ();
		print("New scene loaded");
		Destroy (gameObject);
	}

	void FadeOutBG(){
		fadeIn = true;
		counter = LoadScreenTime;
		isCountingDown = true;
	}
}
