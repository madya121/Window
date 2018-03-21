using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ProjectionMatrixPlayGround : MonoBehaviour {
    public float leftWindow = 1.0f;
    public float rightWindow = 1.0f;
    public float topWindow = 1.0f;
    public float bottomWindow = 1.0f;

    void LateUpdate() {
      float realDistance = -transform.position.z + 50000.0f;

      Camera cam = Camera.main;
      cam.farClipPlane = realDistance;

      float windowDistance = -transform.position.z;

      float top     = ((realDistance * (topWindow - transform.position.y)) / windowDistance) / realDistance;
      float bottom  = ((realDistance * (bottomWindow - transform.position.y)) / windowDistance) / realDistance;
      float left    = ((realDistance * (leftWindow - transform.position.x)) / windowDistance) / realDistance;
      float right   = ((realDistance * (rightWindow - transform.position.x)) / windowDistance) / realDistance;

      Matrix4x4 m = FrustumMatrix(left * (16.0f / 9f), right * (16.0f / 9f), bottom, top, cam.nearClipPlane, cam.farClipPlane);
      cam.projectionMatrix = m;
    }

    private float index = 0;
    void Update() {
      // return;
      index += Time.deltaTime * 0.75f;
      float x = Mathf.Sin (index) * 1.5f;
      // float y = Mathf.Sin (index);
      transform.localPosition= new Vector3(x, transform.position.y, transform.position.z);
    }

    static Matrix4x4 FrustumMatrix(float l, float r, float b, float t, float n, float f) {
        float Xc = 2.0f * n / (r - l);
        float Yc = 2.0f * n / (t - b);
        float A = (r + l) / (r - l);
        float B = (t + b) / (t - b);
        float C = -(f + n) / (f - n);
        float D = -(2.0f * f * n) / (f - n);

        Matrix4x4 m = new Matrix4x4();

        m[0, 0] = Xc; m[0, 1] = 0;  m[0, 2] = A;    m[0, 3] = 0;
        m[1, 0] = 0;  m[1, 1] = Yc; m[1, 2] = B;    m[1, 3] = 0;
        m[2, 0] = 0;  m[2, 1] = 0;  m[2, 2] = C;    m[2, 3] = D;
        m[3, 0] = 0;  m[3, 1] = 0;  m[3, 2] = -1f;  m[3, 3] = 0;

        return m;
    }
}
