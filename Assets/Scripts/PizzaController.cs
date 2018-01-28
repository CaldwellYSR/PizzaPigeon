using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : MonoBehaviour {

	public GameObject GameManager;
	public GameObject Pigeon;

	private ScoreControl ScoreManager;
	private PizzaDropper PizzaDrop;

	public void Start() {
		ScoreManager = GameManager.GetComponent<ScoreControl> ();
		PizzaDrop = Pigeon.GetComponent<PizzaDropper> ();
	}

	public void OnCollisionEnter(Collision other){
		//decrement score
		ScoreManager.DecrementScore();

		//renable pizza fire
		PizzaDrop.ReadyNextPizza();
		
	}

}
