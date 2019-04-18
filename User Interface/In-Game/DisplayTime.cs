using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour {

	public Text TimerText;
	public GameObject CountdownUI;

	// Use this for initialization
	void Start () {
		CountdownUI.SetActive(false);
		WaveQueuedEvent.Register(onWaveQueued);
	}

	void onWaveQueued(WaveQueuedEvent waveQueued)
	{
		Debug.LogFormat("Received WaveQueuedEvent");
		CountdownUI.SetActive(true);
		StartCoroutine(UpdateCountdownClock(waveQueued.TimeQueued));
	}

	IEnumerator UpdateCountdownClock(float timeQueued)
	{
		while (timeQueued > 0)
		{
			TimerText.text = ((int)timeQueued + 1).ToString();
			yield return null;
			timeQueued -= Time.deltaTime;
		}
		CountdownUI.SetActive(false);
	}
}
