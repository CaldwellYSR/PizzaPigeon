using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerControl : MonoBehaviour
{
	public int timeLeft = 5;
	public Text PigeonTimer;
	public Text PersonTimer;
	public string NextLevel;

	// Use this for initialization
	void Start()
	{
		StartCoroutine("LoseTime");
	}

	// Update is called once per frame
	void Update()
	{

		if (timeLeft <= 0) {
			PigeonTimer.text = "Times Up!";
			PersonTimer.text = "Times Up!";

			if (timeLeft <= -3) {
				StopCoroutine ("LoseTime");
				SceneManager.LoadScene (NextLevel);
			}
		} else {
			PigeonTimer.text = ("" + timeLeft);
			PersonTimer.text = ("" + timeLeft);
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