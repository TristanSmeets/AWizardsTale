using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCoreHealthbar : MonoBehaviour {

	public float LerpTime;
	HealthComponent coreHealth;
	ImageSlider imageSlider;
	void Start () {
		coreHealth = GetComponent<HealthComponent>();
		imageSlider = GetComponent<ImageSlider>();

		EntityHitEvent.Register(onEntityHit);
	}

	void onEntityHit(EntityHitEvent entityHit)
	{
		if (entityHit.Tag == "Finish")
			updateHealthbar(entityHit.HealthLeft);
	}

	void updateHealthbar(float currentHealth)
	{
		float healthPercentage = currentHealth / coreHealth.GetTotalHealth();
		StartCoroutine(ImageSlider.ChangeSliderValueUsingEaseOut(imageSlider, healthPercentage, LerpTime));
	}
}
