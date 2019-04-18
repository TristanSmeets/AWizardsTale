using UnityEngine;

[CreateAssetMenu]
public class Statistics : ScriptableObject
{
	[SerializeField]
	int enemiesKilled = 0, fragmentsCollected = 0;
	[SerializeField]
	bool isCompleted;

	public int GetEnemiesKilled() { return enemiesKilled; }
	public int GetFragmentsCollected() { return fragmentsCollected; }
	public bool GetIsCompleted() { return isCompleted; }
	public void IncreaseEnemiesKilled()
	{
		enemiesKilled++;
	}
	public void IncreaseFragmentsCollected()

	{
		fragmentsCollected++;
	}
	public void SetEnemiesKilled(int value)
	{
		enemiesKilled = value;
	}
	public void SetFragmentsCollected(int value)
	{
		fragmentsCollected = value;
	}
	public void SetIsCompleted(bool value)
	{
		isCompleted = value;
	}
	public void ResetValues()
	{
		enemiesKilled = 0;
		fragmentsCollected = 0;
		isCompleted = false;
	}
}
