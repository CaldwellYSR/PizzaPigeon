using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
	public int timeLeft = 5;
	public Text PigeonTimer;
	public Text PersonTimer;

	// Use this for initialization
	void Start()
	{
		StartCoroutine("LoseTime");
	}

	// Update is called once per frame
	void Update()
	{
		PigeonTimer.text = ("" + timeLeft);
		PersonTimer.text = ("" + timeLeft);

		if (timeLeft <= 0)
		{
			StopCoroutine("LoseTime");
			PigeonTimer.text = "Times Up!";
			PersonTimer.text = "Times Up!";
		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}
}