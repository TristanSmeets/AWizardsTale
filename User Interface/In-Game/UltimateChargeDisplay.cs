using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateChargeDisplay : MonoBehaviour {

	public ImageSlider slider;
	[SerializeField]
	float duration = 1;
	//Add some ultimateComponent here for the total amount of charge.

	void Start () {
		UltimateChangeEvent.Register(onUltimateChange);
		slider.FillAmount = 0;
	}

	void onUltimateChange(UltimateChangeEvent ultimateChangeEvent)
	{
		float changePercentage = ultimateChangeEvent.NewValue / ultimateChangeEvent.MaxValue;
		StartCoroutine(ImageSlider.ChangeSliderValueUsingEaseIn(slider, changePercentage, duration));
	}
}
