using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerKontrol : NetworkBehaviour {

	public GameObject bullet;
	public Transform firePoint;
	public GameObject joystick;
	void Update () {
		if (!isLocalPlayer) {
			joystick.SetActive (false);			
			return;
		}
		float x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150f;
		float y = Input.GetAxis ("Vertical") * Time.deltaTime * 10f;

		transform.Rotate (0, 0, -x);
		transform.Translate (0, y, 0);

		if (Input.GetKeyDown (KeyCode.Space)) {
			CmdFire ();
		}
	} 
	public override void OnStartLocalPlayer ()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("tanks2")[1] as Sprite;
	}
	[Command]
	public void CmdFire(){
		GameObject bulletIns = Instantiate (bullet, firePoint.position, firePoint.rotation) as GameObject;
		bulletIns.GetComponent<Rigidbody2D> ().velocity = bulletIns.transform.up * 10;
		NetworkServer.Spawn (bulletIns);
		Destroy (bulletIns, 3);
	}
}
