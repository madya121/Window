using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {

  public Transform window;
  public float windowHeight;

  private Camera camera;

	// Use this for initialization
	void Start () {
    windowHeight /= 2f;

    camera = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {
    calculateFieldOfView();
	}

  void calculateFieldOfView() {
    Vector3 currentPos = transform.position;
    Vector3 windowPos  = window.position;

    float dist = Vector3.Distance(windowPos, currentPos);
    float s = (dist * dist) + (windowHeight * windowHeight);
    s = Mathf.Sqrt(s);

    float fov = Mathf.Acos(dist / s) * Mathf.Rad2Deg * 2f;
    Debug.Log(dist + " " + s + " " + fov);

    camera.fieldOfView = fov;

    transform.LookAt(Vector3.zero);
  }
}
