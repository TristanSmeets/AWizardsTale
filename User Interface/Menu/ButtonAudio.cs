using UnityEngine;

public class ButtonAudio : MonoBehaviour
{

	public AudioClip RollOverClip;
	public AudioClip ClickClip;

	public AudioSource audioSource;

	[SerializeField, Range(0, 1)]
	float rollOverVolume = 1, clickVolume = 1;

	public void PlayRollOver()
	{
		audioSource.PlayOneShot(RollOverClip, rollOverVolume);
	}

	public void PlayClick()
	{
		audioSource.PlayOneShot(ClickClip, clickVolume);
	}
}
