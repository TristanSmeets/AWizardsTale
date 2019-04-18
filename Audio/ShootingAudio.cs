using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootingAudio : MonoBehaviour {
	public AudioClip Clip;
	public Keybindings keys;

	[SerializeField, Range(0,1)]
	float volume;
	float previous = 0;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (InputWrapper.GetPrimary(keys) > 0 && previous <= 0.001f)
		{
			playAudioClip(Clip, volume);
		}
		previous = InputWrapper.GetPrimary(keys);
	}

	void playAudioClip(AudioClip clip, float volume)
	{
		audioSource.PlayOneShot(clip, volume);
	}
}
