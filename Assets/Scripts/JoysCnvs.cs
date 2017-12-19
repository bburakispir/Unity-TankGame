using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysCnvs : MonoBehaviour {
	
	void Update () {
		transform.position = new Vector3 (38.44f, 14.2f, transform.position.z);
		transform.rotation = Quaternion.Euler (0f, 0f, 0f);
	}
}
