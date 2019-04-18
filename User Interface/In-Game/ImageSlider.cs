using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSlider : MonoBehaviour {

	public Image FillImage;

	void Start() {
	}

	public static float Lerp(float startValue, float endValue, float time)
	{
		time = Mathf.Clamp01(time);
		return (startValue + (endValue - startValue) * time);
	}

	public static float EaseIn(float t)
	{
		return t * t;
	}

	public static float Flip(float x)
	{
		return 1 - x;
	}

	public static float EaseOut(float t)
	{
		return Flip(EaseIn(Flip(t)));
	}

	public float FillAmount { get { return FillImage.fillAmount; } set { FillImage.fillAmount = value; } }

	public float GetSliderValue() { return FillImage.fillAmount; }
	public void SetSliderValue(float value)
	{
		FillImage.fillAmount = value;
	}

	public static IEnumerator ChangeSliderValueUsingEaseOut(ImageSlider imageSlider, float endValue, float duration)
	{
		float ElapsedTime = 0;
		float startValue = imageSlider.FillAmount;

		while (ElapsedTime <= duration)
		{
			imageSlider.FillAmount = ImageSlider.Lerp(startValue, endValue, EaseOut(ElapsedTime / duration));
			yield return null;
			ElapsedTime += Time.unscaledDeltaTime;
		}
	}

	public static IEnumerator ChangeSliderValueUsingEaseIn(ImageSlider imageSlider, float endValue, float duration)
	{
		float ElapsedTime = 0;
		float startValue = imageSlider.FillAmount;

		while (ElapsedTime <= duration)
		{
			imageSlider.FillAmount = ImageSlider.Lerp(startValue, endValue, EaseIn(ElapsedTime / duration));
			yield return null;
			ElapsedTime += Time.deltaTime;
		}
	}
}
