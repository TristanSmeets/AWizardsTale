using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy;

	[SerializeField]
	float cooldownTime = 1.5f, timeOffset = 0.5f;
	Spawner spawner;

	void Start () {
		spawner = gameObject.GetComponent<Spawner>();
		WaveStartEvent.Register(onWaveStart);
	}

	void onWaveStart(WaveStartEvent waveStartEvent)
	{
		GameObject CrystalFragment = waveStartEvent.CrystalFragment;
		int AmountOfEnemies = waveStartEvent.AmountOfEnemies;
		spawner.SpawnMultipleObjects(Enemy,
			CrystalFragment.transform.position, 
			CrystalFragment.transform.rotation,
			AmountOfEnemies, 
			cooldownTime, 
			timeOffset);
	}
}
