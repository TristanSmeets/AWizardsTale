using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectedAudio : MonoBehaviour {

	public AudioClip Clip;

	[SerializeField, Range(0, 1)]
	float volume;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		ItemCollectedEvent.Register(onItemCollected);
	}

	void onItemCollected(ItemCollectedEvent itemCollected)
	{
		if (itemCollected.Item.Equals(gameObject))
		{
			Debug.LogFormat("Playing {0} collected sound", gameObject);
			audioSource.PlayOneShot(Clip, volume);
		}
	}
}
