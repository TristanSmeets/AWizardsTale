using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingAudio : MonoBehaviour {

	public AudioClip Clip;

	[SerializeField, Range(0, 1)]
	float volume;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		EntityKilledEvent.Register(onEntityKilled);
	}

	void onEntityKilled(EntityKilledEvent entityKilled)
	{
		if (entityKilled.Entity.Equals(gameObject))
		{
			Debug.LogFormat("Playing dying sound");
			audioSource.PlayOneShot(Clip, volume);
		}
	}

	private void OnDestroy()
	{
		EntityKilledEvent.DeRegister(onEntityKilled);
	}
}
