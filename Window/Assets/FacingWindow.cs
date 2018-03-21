using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingWindow : MonoBehaviour {

  public Transform windowTransform;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.LookAt(windowTransform.position);

    // Limit into 3 meter area
    Vector3 pos = transform.localPosition;
    pos.z = Mathf.Min(pos.z, -13);
    pos.z = Mathf.Max(pos.z, -16);

    pos.x = Mathf.Min(pos.x, 1.5f);
    pos.x = Mathf.Max(pos.x, -1.5f);

    transform.localPosition = pos;
	}
}
