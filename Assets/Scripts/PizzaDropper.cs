using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaDropper : MonoBehaviour {

  public GameObject Crosshair;
  public GameObject Pizza;

  private bool Tracking = true;
  private float TimeToTarget;
  private float Gravity = Mathf.Abs(Physics.gravity.y);
  private float HeightOffset = 10f;
  private Rigidbody Body;
  private GameObject CrosshairInstance;
  private GameObject PizzaInstance;

  void Start() {
    Body = GetComponent<Rigidbody>();
    CrosshairInstance = GameObject.Instantiate(Crosshair);
  }

  void Update() {
    if (Input.GetButtonDown("DropBomb") && Tracking) {
      Tracking = false;
      PizzaInstance = GameObject.Instantiate(Pizza);
      PizzaInstance.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
      PizzaInstance.GetComponent<Rigidbody>().velocity = new Vector3(Body.velocity.x, 0, Body.velocity.z);
    }
  }

  void LateUpdate() {
    if (Tracking) {
      CrosshairInstance.transform.position = GetCrosshairPosition();
    }
  }

  private Vector3 GetCrosshairPosition() {
    return new Vector3(transform.position.x + GetXDisplacement(), HeightOffset, transform.position.z + GetZDisplacement());
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
