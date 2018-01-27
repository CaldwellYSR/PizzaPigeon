using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera Control/Smooth Follow")]
public class FollowTarget : MonoBehaviour {

  public Transform Target;

  [Range(7f, 15f)]
  public float Distance = 10f;

  [Range(3f, 8f)]
  public float Height = 5f;

  [Range(1f, 3f)]
  public float HeightDamping = 2f;

  [Range(2f, 4f)]
  public float RotationDamping = 3f;

	void LateUpdate () {

    float desiredRotationAngle = Target.eulerAngles.y;
    float desiredHeight = Target.position.y + Height;
    float currentRotationAngle = transform.eulerAngles.y;
    float currentHeight = transform.position.y;

    currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, desiredRotationAngle, RotationDamping * Time.deltaTime);
    currentHeight = Mathf.Lerp(currentHeight, desiredHeight, HeightDamping * Time.deltaTime);

    Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

    transform.position = Target.position - currentRotation * Vector3.forward * Distance + new Vector3(0, Height, 0);

    transform.LookAt(Target);

	}
}
