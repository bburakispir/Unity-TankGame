using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	public int maxHealth=4;
	public bool nesne;
	public bool destroyOnDeath;
	[SyncVar(hook="OnChangeHealth")]
	public int currentHealth;
	public RectTransform healthBar;

	void Start(){
		currentHealth = maxHealth;
		if (isLocalPlayer) {
			PlayerPrefs.SetString ("Position", transform.position.x + "," + transform.position.y + "," + transform.position.z);
			PlayerPrefs.SetString ("Rotation", transform.rotation.x + "," + transform.rotation.y + "," + transform.rotation.z);
		}

	}
	public void TakeDamage(int damageAmount){
		if (!isServer)
			return;
		currentHealth -= damageAmount;
		if(currentHealth<=0){
			if (destroyOnDeath) {
				Destroy (gameObject);
			} 
			else {
				currentHealth=maxHealth;
				RpcRespawn ();
			}

			Debug.Log("ben öldüm");
		}


	}
	void OnChangeHealth(int health){
		if(!nesne)
			healthBar.sizeDelta = new Vector2 (((float) (4 / ((float)maxHealth))*((float) health)), healthBar.sizeDelta.y); 
	}
	[ClientRpc]
	void RpcRespawn(){
		if (isLocalPlayer) {
			string[] PlayerTransform;
			PlayerTransform = PlayerPrefs.GetString ("Position").Split (',');
			Vector3 pos = new Vector3 (float.Parse (PlayerTransform [0]), float.Parse (PlayerTransform [1]), float.Parse (PlayerTransform [2]));
			PlayerTransform = PlayerPrefs.GetString ("Rotation").Split (',');
			Quaternion rot = Quaternion.Euler (float.Parse (PlayerTransform [0]), float.Parse (PlayerTransform [1]), float.Parse (PlayerTransform [2]));  
			transform.position = pos;
			transform.rotation = rot;
			Debug.Log (pos);
		}


	}
}
