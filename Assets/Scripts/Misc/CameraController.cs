using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    float smoothing = 5;

	void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * smoothing;
    }
}
