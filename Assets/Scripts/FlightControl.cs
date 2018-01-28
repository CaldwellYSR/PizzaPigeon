using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour {

  [Range(4f, 24f)]
  public float Speed;

  [Range(0.5f, 2f)]
  public float TurnSpeed;

  [Range(10f, 50f)]
  public float MaxSpeed;

  private Rigidbody Body;
  private Vector3 Direction;

  void Start() {
    Body = GetComponent<Rigidbody>();
  }

	void FixedUpdate () {

    Body.AddTorque(transform.up * Input.GetAxis("Horizontal") * TurnSpeed);
    Body.AddTorque(transform.right * Input.GetAxis("Vertical") * TurnSpeed);

    if (Input.GetButtonDown("Boost")) {
      Speed *= 2f;
    }
    if (Input.GetButtonUp("Boost")) {
      Speed *= 0.5f;
    }

    if (Input.GetButtonDown("Brake")) {
      Speed *= 0.5f;
    }
    if (Input.GetButtonUp("Brake")) {
      Speed *= 2f;
    }

    Body.AddForce(transform.forward * Speed);

    Quaternion desiredRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime);

    if (Body.velocity.magnitude >= MaxSpeed) {
      Body.velocity = Body.velocity.normalized * MaxSpeed;
    }
	}
}
