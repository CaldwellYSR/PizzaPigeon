using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : MonoBehaviour {

	public ScoreControl ScoreManager;
	public PizzaDropper PizzaDrop;

	public void OnCollisionEnter(Collision other){
		ScoreManager.DecrementScore();
		PizzaDrop.ReadyNextPizza();
	}

}
