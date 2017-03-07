using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	public int rotateSpeed = 1;
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
	}
}
