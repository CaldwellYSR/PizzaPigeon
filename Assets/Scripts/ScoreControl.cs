using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour {

	public int PlayerScore = 0;
	public int CorrectPizza = 500;
	public int WrongPizza = -100;

	public void DecrementScore(){
		PlayerScore += WrongPizza;
		Debug.Log ("Decremented: " + PlayerScore);
	}


}