using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaDropper : MonoBehaviour {

  public GameObject Crosshair;
  public GameObject Pizza;
  public Collider Map;
  public bool PizzaReady = true;


	private GameObject[] Pizzas;
  private float TimeToTarget;
  private float Gravity = Mathf.Abs(Physics.gravity.y);
  private float HeightOffset = 10f;
  private Rigidbody Body;
  private GameObject CrosshairInstance;
  private GameObject PizzaInstance;

  void Start() {
    Body = GetComponent<Rigidbody>();
    CrosshairInstance = GameObject.Instantiate(Crosshair);
		Pizzas = GameObject.FindGameObjectsWithTag ("Pizza");
  }

  void Update() {
    if (Input.GetButtonDown("DropBomb") && PizzaReady) {
			PizzaReady = false;
			PizzaInstance = Pizzas [0];
      PizzaInstance.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
      PizzaInstance.GetComponent<Rigidbody>().velocity = new Vector3(Body.velocity.x, 0, Body.velocity.z);
    }
  }

  void LateUpdate() {
    CrosshairInstance.transform.position = GetCrosshairPosition();
  }

	public void ReadyNextPizza() {
		Debug.Log ("Ready Dat Pizza Bitch");
		PizzaReady = true;
	}

  private Vector3 GetCrosshairPosition() {
    float xPos = transform.position.x + GetXDisplacement();
    float zPos = transform.position.z + GetZDisplacement();
    HeightOffset = GetHeightOffset(xPos, zPos);

    return new Vector3(xPos, HeightOffset, zPos);
  }

  private float GetHeightOffset(float xPos, float zPos) {
    Vector3 origin = new Vector3(xPos, transform.position.y, zPos);
    Ray ray = new Ray(origin, Vector3.down);
    RaycastHit hit;
    if (Map.Raycast(ray, out hit, 100f)) {
      return hit.point.y + 0.5f;
    }
    return 0;
  }

  private float GetXDisplacement() {
    return Body.velocity.x * GetTimeToTarget();
  }

  private float GetZDisplacement() {
    return Body.velocity.z * GetTimeToTarget();
  }

  private float GetTimeToTarget() {
    return Mathf.Sqrt((2 * (transform.position.y - HeightOffset)) / Gravity);
  }

}
