using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public float tilt;

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = movement * speed;

		float newX = Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax);
		float newZ = Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax);

		rigidbody.position = new Vector3 (newX, 0.0f, newZ);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
