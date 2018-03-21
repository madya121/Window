using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFrames : MonoBehaviour {

  public Sprite frame;

	// Use this for initialization
	void Start () {
    for (int i = 0; i < 20; i++) {
      GameObject obj = new GameObject("Frame " + i);
      Vector3 position = new Vector3(0, 0, (float)i * 2f);
      Vector3 scale = new Vector3(1.2f, 1.2f, 1);
      obj.transform.position = position;
      obj.transform.localScale = scale;

      obj.AddComponent<SpriteRenderer>();
      SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
      sr.sprite = frame;
    }
	}

	// Update is called once per frame
	void Update () {

	}
}
