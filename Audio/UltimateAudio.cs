using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAudio : MonoBehaviour {

	public AudioClip UltimateClip;
	[SerializeField, Range(0, 1)]
	float volume = 1;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		UltimateChangeEvent.Register(onUltimateChange);
	}

	void onUltimateChange(UltimateChangeEvent ultimateChange)
	{
		if (ultimateChange.NewValue == 0 && ultimateChange.OldValue != 0)
		{
			Debug.LogFormat("Playing Ultimate Sound");
			audioSource.PlayOneShot(UltimateClip, volume);
		}
	}
}
