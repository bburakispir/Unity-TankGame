using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		var hit = col.gameObject;
		var health = hit.GetComponent<Health> ();

		if (health != null) {
			health.TakeDamage (1);
		}
		Destroy (gameObject);
	}
}
