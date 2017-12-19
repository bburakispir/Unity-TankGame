using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour {

	public GameObject player;

	void Update(){
		Debug.Log ("Up "+player.transform.rotation.z);

	}

	public void upButtonClick(){
		//player.transform.rotation = Quaternion.Euler (0, 0, 0);
		//player.transform.Translate (player.transform.up.x * 2f, player.transform.up.y * 2f, 0);
		player.transform.position+=player.transform.up*0.5f;
	}

	public void downButtonClick(){
		//player.transform.rotation = Quaternion.Euler (0, 0, 180);
		//player.transform.Translate (player.transform.up.x * 2f, -player.transform.up.y * 2f, 0);
		player.transform.position-=player.transform.up*0.5f;
	}

	public void leftButtonClick(){
		//player.transform.rotation = Quaternion.Euler (0, 0, 90);
		//player.transform.Translate (player.transform.right.x * 2f, player.transform.right.y * 2f, 0);
		player.transform.Rotate(0,0,10f);
	}

	public void rightButtonClick(){
		//player.transform.rotation = Quaternion.Euler (0, 0, -90);
		//player.transform.Translate (player.transform.right.x * 2f, -player.transform.right.y * 2f, 0);
		player.transform.Rotate(0,0,-10f);
	}
}
