using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour {

	public int PlayerScore = 0;
	public int CorrectPizza = 20;
	public int WrongPizza = -5;
	public Text PigeonDollas;

	public void DecrementScore(){
		PlayerScore += WrongPizza;
		PigeonDollas.text = ("$" + PlayerScore);
	}

  public void IncrementScore() {
		PlayerScore += CorrectPizza;
		PigeonDollas.text = ("$" + PlayerScore);
  }
}
