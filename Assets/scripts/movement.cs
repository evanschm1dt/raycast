using UnityEngine;
using System.Collections;


public class movement : MonoBehaviour {
	
	public float movespeed;

	// Update is called once per frame
	void Update () {
		Ray moveRay = new Ray (transform.position, transform.forward);
		GetComponent <Rigidbody> ().velocity = transform.forward * movespeed + Physics.gravity;
		if (Physics.SphereCast (moveRay, 1f, 0.8f) == true) {
			float randomNumber = Random.value;
			if (randomNumber > 0.5) {
				transform.Rotate (new Vector3 (0, 90f, 0));
			} else {
				transform.Rotate (new Vector3 (0, -90f, 0));
			}
		}
	}
}
