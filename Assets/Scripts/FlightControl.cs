using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour {

  [Range(1, 6)]
  public float Speed;

  [Range(10, 100)]
  public float MaxSpeed;

  private Rigidbody Body;
  private Vector3 Direction;

  void Start() {
    Body = GetComponent<Rigidbody>();
    Direction = transform.forward;
  }

	void FixedUpdate () {
    Body.AddForce(Direction * Speed);

    if (Body.velocity.magnitude >= MaxSpeed) {
      Body.velocity = Body.velocity.normalized * MaxSpeed;
    }
	}
}
