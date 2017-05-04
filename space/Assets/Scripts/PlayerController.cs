using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;

	private float nextFire = 0.0f;

	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

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
