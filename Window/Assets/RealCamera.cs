using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealCamera : MonoBehaviour {

  public float planeWidth;
  public float fov;

  public Transform otherCameraTransform;
  public Transform windowTransform;
  public float windowSize;

  private float realWindowOnPlane;

	// Use this for initialization
	void Start () {
    calculateWindowSizeOnPlane();
	}

	// Update is called once per frame
	void Update () {
    calculateWindowSizeOnPlane();
    calculateCurrentCameraDistance();
	}

  void calculateCurrentCameraDistance() {
    float z = (realWindowOnPlane / 2.0f) / Mathf.Tan((fov / 2.0f) * Mathf.Deg2Rad);
    Vector3 pos = transform.position;
    pos.z = -z;
    transform.position = pos;
  }

  void calculateWindowSizeOnPlane() {
    Vector3 otherCameraPos = otherCameraTransform.position;
    Vector3 windowPos = windowTransform.position;

    float dist = Vector3.Distance(windowPos, otherCameraPos);
    float degree = fov / 2.0f;
    float window = windowSize / 2.0f;

    float frontSize = Mathf.Tan(degree * Mathf.Deg2Rad) * dist;
    float windowRatio = window / frontSize;

    realWindowOnPlane = windowRatio * planeWidth;
    Debug.Log(realWindowOnPlane);
  }
}
