using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

  public ScoreControl ScoreManager;
  public PizzaDropper DroppingBombAssPizzas;

  private List<GameObject> AvailablePersons;
  private List<GameObject> SelectedPersonsList = new List<GameObject>();
  private int SelectedPersonIndex;
  private GameObject SelectedPerson;

  public void Start() {

    AvailablePersons = new List<GameObject>(GameObject.FindGameObjectsWithTag("Person"));
    SelectNewPerson();

  }

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Pizza")) {
      Destroy(other.gameObject);
      ScoreManager.IncrementScore();
      DroppingBombAssPizzas.ReadyNextPizza();
      SelectNewPerson();
    }
  }

  private void SelectNewPerson() {
    SelectedPersonIndex = (int) Mathf.Floor(Random.Range(0, AvailablePersons.Count));
    SelectedPerson = AvailablePersons[SelectedPersonIndex];

    AvailablePersons.RemoveAt(SelectedPersonIndex);
    SelectedPersonsList.Add(SelectedPerson);

    SelectedPerson.layer = 8;

    transform.position = new Vector3(
      SelectedPerson.transform.position.x,
      SelectedPerson.transform.position.y + 6f,
      SelectedPerson.transform.position.z
    );
  }

}
