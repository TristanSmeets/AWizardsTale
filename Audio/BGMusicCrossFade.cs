using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BGMusicCrossFade : MonoBehaviour {

	public AudioSource BGAudioSource1;
	public AudioSource BGAudioSource2;
	public float MinValue;
	public float MaxValue;
	public float duration;

	bool collectedFirstCrystal = false;
	// Use this for initialization
	void Start () {
		CrystalCollectedEvent.Register(onCrystalCollected);
		
	}

	void onCrystalCollected(CrystalCollectedEvent crystalCollected)
	{
		if (!collectedFirstCrystal)
		{
			crossFadeTracks();
			collectedFirstCrystal = true;
		}
	}

	void crossFadeTracks()
	{
		StartCoroutine(lerpVolumeLevels(BGAudioSource1, MinValue, duration));
		StartCoroutine(lerpVolumeLevels(BGAudioSource2, MaxValue, duration));
	}

	void Update () {
		
	}

	IEnumerator lerpVolumeLevels(AudioSource audioSource, float endValue, float duration)
	{
		float ElapsedTime = 0;
		float startValue = audioSource.volume;

		while (ElapsedTime <= duration)
		{
			audioSource.volume = ImageSlider.Lerp(startValue, endValue, ImageSlider.EaseOut(ElapsedTime / duration));
			yield return null;
			ElapsedTime += Time.unscaledDeltaTime;
		}
	}
}
