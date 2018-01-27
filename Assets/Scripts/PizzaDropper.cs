using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaDropper : MonoBehaviour {

  public GameObject Crosshair;
  private float TimeToTarget;
  private float Gravity = Mathf.Abs(Physics.gravity.y);
  private Rigidbody Body;

  void Start() {
    Body = GetComponent<Rigidbody>();
    Crosshair = GameObject.Instantiate(Crosshair);
  }

  void LateUpdate() {
    Crosshair.transform.position = GetCrosshairPosition();
  }

  private Vector3 GetCrosshairPosition() {
    return new Vector3(transform.position.x + GetXDisplacement(), 15, transform.position.z + GetZDisplacement());
  }

  private float GetXDisplacement() {
    return Body.velocity.x * GetTimeToTarget();
  }

  private float GetZDisplacement() {
    return Body.velocity.z * GetTimeToTarget();
  }

  private float GetTimeToTarget() {
    return Mathf.Sqrt((2 * transform.position.y) / Gravity);
  }

}
