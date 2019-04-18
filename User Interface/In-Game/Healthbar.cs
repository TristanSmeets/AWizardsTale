using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
	GameObject playerObject;
	public ImageSlider ImageSlider;
	public float LerpTime;
	HealthComponent playerHealth;

	void Start () {
		//Subscribing to GameEvents
		EntityHitEvent.Register(onEntityHit);
		ItemCollectedEvent.Register(onItemCollected);

		//Finding Player Oject
		playerObject = GameObject.FindGameObjectWithTag("Player");
		playerHealth = playerObject.GetComponent<HealthComponent>();

		//UI Slider
		ImageSlider.SetSliderValue(1);
	}

	void onEntityHit(EntityHitEvent entityHit)
	{
		if (entityHit.Entity.Equals(playerObject))
		{
			Debug.LogFormat("{0} got hit", playerObject);
			updateHealthbar(entityHit.HealthLeft);
		}
	}

	void onItemCollected(ItemCollectedEvent itemCollected)
	{
		if (itemCollected.PlayerUpgrade.GetHealth() > 0)
		{
			float healthIncrease = playerHealth.GetTotalHealth() * itemCollected.PlayerUpgrade.GetHealth();
			updateHealthbar(playerHealth.GetCurrentHealth() + healthIncrease);
		}
	}

	void updateHealthbar(float currentHealth)
	{
		float healthPercentage = currentHealth / playerHealth.GetTotalHealth();
		StartCoroutine(ImageSlider.ChangeSliderValueUsingEaseOut(ImageSlider, healthPercentage, LerpTime));
	}
}
