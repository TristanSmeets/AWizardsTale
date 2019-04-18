using UnityEngine;

public class GettingHitAudio : MonoBehaviour
{
	public AudioClip Clip;

	[SerializeField, Range(0, 1)]
	float volume = 1;
	public AudioSource audioSource;
	// Use this for initialization
	void Start()
	{
		EntityHitEvent.Register(onEntityHit);
	}

	void onEntityHit(EntityHitEvent entityHit)
	{
		if (entityHit.Entity.Equals(gameObject))
		{
			audioSource.PlayOneShot(Clip, volume);
		}
	}

	private void OnDestroy()
	{
		EntityHitEvent.DeRegister(onEntityHit);
	}
}
