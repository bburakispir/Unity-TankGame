using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour {
	public GameObject player;
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, 
			player.transform.position.y+8f, transform.position.z);
		transform.rotation = Quaternion.Euler (0f, 0f, 0f);
	}
}
