using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour {

  [Range(4f, 12f)]
  public float Speed;

  [Range(0.5f, 2f)]
  public float TurnSpeed;

  [Range(10f, 100f)]
  public float MaxSpeed;

  private Rigidbody Body;
  private Vector3 Direction;

  void Start() {
    Body = GetComponent<Rigidbody>();
  }

	void FixedUpdate () {

    Body.AddTorque(transform.up * Input.GetAxis("Horizontal") * TurnSpeed);
    Body.AddTorque(transform.right * Input.GetAxis("Vertical") * TurnSpeed);

    Body.AddForce(transform.forward * Speed);

    Quaternion desiredRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime);

    if (Body.velocity.magnitude >= MaxSpeed) {
      Body.velocity = Body.velocity.normalized * MaxSpeed;
    }
	}
}
