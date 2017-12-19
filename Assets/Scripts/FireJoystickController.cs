using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireJoystickController : MonoBehaviour {

	public GameObject player;

	public void FireButtonClick(){
		player.GetComponent<PlayerKontrol> ().CmdFire ();
	}

}
