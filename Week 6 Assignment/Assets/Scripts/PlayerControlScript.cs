using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {
	
	public float speed = 1; //movement speed

	public KeyCode upKey = KeyCode.W; //sets variables for WASD keys
	public KeyCode downKey = KeyCode.S;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Move(Vector3.up, upKey); //calls move fucntion with appropriate vector based on key press
		Move(Vector3.down, downKey);
		Move(Vector3.left, leftKey);
		Move(Vector3.right, rightKey);
	}

	void Move(Vector3 dir, KeyCode key){ //function takes vector three for direction and key for input
		if(Input.GetKey(key)){ //if key is being pressed
			transform.Translate(dir * speed * Time.deltaTime); //move in the given vector, at speed, made framerate independent
		}
	}
}
