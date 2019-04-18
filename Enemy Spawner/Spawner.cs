using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	IEnumerator coroutine;

	/// <summary>
	/// Spawn function that takes 4 parameters:
	/// - GameObject it needs to spawn.
	/// - Vector3 for the spawn position.
	/// - Quaternion for the rotation.
	/// - int for the amount of objects it needs to spawn.
	/// - float for the time between objects. 
	/// - float for the offset for the randomisation.
	/// </summary>
	/// <param name="objectToSpawn"></param>
	/// <param name="position"></param>
	/// <param name="rotation"></param>
	/// <param name="amountToSpawn"></param>
	/// <param name="cooldownTime"></param>
	public void SpawnMultipleObjects(GameObject objectToSpawn, Vector3 position, Quaternion rotation, int amountToSpawn, float cooldownTime, float offset)
	{
		coroutine = SpawnObjects(objectToSpawn, position, rotation, amountToSpawn, cooldownTime, offset);
		StartCoroutine(coroutine);
	}

	IEnumerator SpawnObjects(GameObject objectToSpawn, Vector3 position, Quaternion rotation, int amountOfEnemies, float cooldownTime, float offset)
	{
		for (int iteration = 0; iteration < amountOfEnemies; iteration++)
		{
			Instantiate(objectToSpawn, position, rotation);
			yield return new WaitForSeconds(Random.Range(cooldownTime - offset, cooldownTime + offset));
		}
	}
}
