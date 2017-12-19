using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CreateMap : NetworkBehaviour {

	public GameObject bricksPrefab;
	public GameObject eaglePrefab;
	public GameObject stonePrefab;

	public override void OnStartServer (){
		TextAsset map = Resources.Load<TextAsset>("Maps/harita") as TextAsset;
		LoadMap (map.text);
	}
	void LoadMap(string map){
		string[] lines = map.Split ("\n" [0]);
		for (int i = 0; i < lines.Length; i++) {
			if (lines [i] != null) {
				string[] parts = lines [i].Split ("," [0]);
				GameObject nesne=null;
				if (parts [0].Contains ("Bricks")) {
					nesne = bricksPrefab;
				} 
				else if(parts [0].Contains ("Stone2")){
					nesne = stonePrefab;
				}
				else
					nesne = eaglePrefab;
				GameObject gameObj = Instantiate (nesne, new Vector3 (float.Parse (parts [1]), float.Parse (parts [2]), -2.0f), Quaternion.identity) as GameObject;
				NetworkServer.Spawn (gameObj);
			}
		}
	}
}
