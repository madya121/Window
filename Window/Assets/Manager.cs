using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public Camera cameraA;

	public Material cameraMatA;

	// Use this for initialization
	void Start () {
		if (cameraA.targetTexture != null) {
			cameraA.targetTexture.Release();
		}
		cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatA.mainTexture = cameraA.targetTexture;
	}

}
