using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenAnimation : MonoBehaviour
{
	public Image image;
	public float FadingTime;
	public GameObject RootObject;
	bool isActive;
	bool isFading;
	float counter;

	public void PlayBlinkingAnimation()
	{
		isFading = false;
		isActive = true;
		counter = 0;
		imageAlphaToZero();
	}

	public void PlayFadeOutAnimation()
	{
		isActive = false;
		image.CrossFadeAlpha(0, FadingTime, false);
		Destroy(RootObject, FadingTime);
	}

	// Update is called once per frame
	void Update()
	{
		blinkingAnimation();
		image.gameObject.transform.Rotate(0, 0, 1);
	}

	private void blinkingAnimation()
	{
		if (isActive)
			counter += Time.deltaTime;

		if (counter > FadingTime)
		{
			isFading = !isFading;
			counter = 0;
		}

		if (isActive && !isFading)
			image.CrossFadeAlpha(1, FadingTime, false);
		else if (isActive && isFading)
			image.CrossFadeAlpha(0, FadingTime, false);
	}

	void imageAlphaToZero()
	{
		image.CrossFadeAlpha(0, 0, false);
	}
}
