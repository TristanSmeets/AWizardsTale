using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCollectedAudio : MonoBehaviour {

	public AudioClip Clip;

	[SerializeField, Range(0, 1)]
	float volume = 1;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		CrystalCollectedEvent.Register(onCrystalCollected);
	}

	void onCrystalCollected(CrystalCollectedEvent crystalCollected)
	{
		if (crystalCollected.CrystalFragment.Equals(gameObject))
		{
			audioSource.PlayOneShot(Clip, volume);
		}
	}
}
