using UnityEngine;
using System.Collections;

public class mouse : MonoBehaviour {

	public Transform catPosition;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 directionToCat = catPosition.position - transform.position;
		if (Vector3.Angle(transform.forward, directionToCat) < 180) {
			Ray mouseRay = new Ray (transform.position, directionToCat);
			RaycastHit mouseRayHitInfo = new RaycastHit ();
			if (Physics.Raycast(mouseRay, out mouseRayHitInfo, 20f)){
				if (mouseRayHitInfo.collider.tag == "cat") {
					GetComponent<Rigidbody> ().AddForce (-directionToCat.normalized * 1000f);
				}
			}
		}
	}
}
