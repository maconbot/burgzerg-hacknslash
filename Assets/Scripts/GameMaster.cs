using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject playerCharacter;
	public Camera mainCamera;
	public GameObject gameSettings;
	public float zOffset;
	public float yOffset;
	public float xRotOffset;

	private GameObject _pc;
	private PlayerCharacter pcScript;

	// Use this for initialization
	void Start () 
	{
		_pc = Instantiate (playerCharacter, Vector3.zero, Quaternion.identity) as GameObject;
		_pc.name = "pc";
		pcScript = _pc.GetComponent<PlayerCharacter> ();

		zOffset = -2.5f;
		yOffset = 2.5f;
		xRotOffset = 22.5f;

		mainCamera.transform.position = new Vector3(_pc.transform.position.x, 
		                                            _pc.transform.position.y + yOffset, 
		                                            _pc.transform.position.z + zOffset);

		mainCamera.transform.Rotate (xRotOffset, 0, 0);

		loadCharacter ();
	}

	public void loadCharacter()
	{
		GameObject gs = GameObject.Find ("__Game Settings");
		if(gs == null)
		{
			GameObject gs1 = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
			gs1.name = "__Game Settings";
		}
		GameSettings gsScript = GameObject.Find("__Game Settings").GetComponent<GameSettings>();
		
		gsScript.LoadCharacterData();
	}
}
