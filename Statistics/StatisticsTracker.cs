using UnityEngine;

public class StatisticsTracker : MonoBehaviour
{

	public Statistics playerStatistics;
	public GameObject CrystalCore;
	ConditionChecker conditionChecker;

	void Start()
	{
		playerStatistics.ResetValues();
		EntityKilledEvent.Register(onEntityKilled);
		CrystalDeliveredEvent.Register(onCrystalDelivered);
		conditionChecker = GetComponent<ConditionChecker>();
	}

	void onEntityKilled(EntityKilledEvent entityKilled)
	{
		if (entityKilled.Entity == null)
			return;

		Debug.LogFormat("Received EntityKilled. KillerTag: {0}", entityKilled.KillerTag);
		if (entityKilled.KillerTag == "Projectile")
		{
			playerStatistics.IncreaseEnemiesKilled();
		}
	}
	void onCrystalDelivered(CrystalDeliveredEvent crystalDelivered)
	{
		playerStatistics.IncreaseFragmentsCollected();
		conditionChecker.OnCrystalDelivered(playerStatistics);
	}
}
