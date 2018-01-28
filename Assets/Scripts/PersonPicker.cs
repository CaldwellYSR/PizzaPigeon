using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPicker : MonoBehaviour {

	public List<Sprite> Peoples;

	private SpriteRenderer Sprite;

	void Start() {
		Sprite = GetComponent<SpriteRenderer> ();
		int selected = (int) Mathf.Floor(Random.Range (0, Peoples.Count));
		Sprite.sprite = Peoples[selected];
	}

}
