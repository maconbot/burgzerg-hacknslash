using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject gameCharacter;

	// Use this for initialization
	void Start () 
	{
		Instantiate (gameCharacter, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
