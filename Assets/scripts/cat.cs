using UnityEngine;
using System.Collections;

public class cat : MonoBehaviour {

	public Transform mouse;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (mouse == null) {
			return;
		}

		Vector3 directionToMouse = mouse.position - transform.position;
		if (Vector3.Angle (transform.forward, directionToMouse) < 180) {
			Ray catRay = new Ray (transform.position, directionToMouse);
			RaycastHit catRayHitInfo = new RaycastHit ();
			if (Physics.Raycast (catRay, out catRayHitInfo, 15f)) {
				if (catRayHitInfo.collider.tag == "mouse") {
					if (catRayHitInfo.distance <= 1) {
						Destroy (mouse.gameObject);
						AudioSource audio = GetComponent<AudioSource>();
						audio.Play();
					} else {
						GetComponent<Rigidbody> ().AddForce (directionToMouse.normalized * 1000f);
					}
				}
			}
		}
					
	}
}
