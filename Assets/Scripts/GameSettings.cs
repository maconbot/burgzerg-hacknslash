using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {

	void Awake()
	{
		// Tells game that you should not destroy this game object when you load from
		// scene to scene!
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SaveCharacterData()
	{
		GameObject pc = GameObject.Find ("pc");
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter> ();

		//PlayerPrefs.DeleteAll ();

		PlayerPrefs.SetString ("Player Name", pcClass.Name);

		for(int i = 0; i < Enum.GetValues (typeof(AttributeName)).Length; i++)
		{
			PlayerPrefs.SetInt (((AttributeName) i).ToString() + " - Base Value", pcClass.getPrimaryAttribute(i).BaseValue);
			PlayerPrefs.SetInt (((AttributeName) i).ToString() + " - EXP To Level", pcClass.getPrimaryAttribute(i).ExpToLevel);
		}

		for(int i = 0; i < Enum.GetValues (typeof(VitalName)).Length; i++)
		{
			PlayerPrefs.SetInt (((VitalName) i).ToString() + " - Base Value", pcClass.getVital(i).BaseValue);
			PlayerPrefs.SetInt (((VitalName) i).ToString() + " - Current Value", pcClass.getVital(i).CurrentValue);
			PlayerPrefs.SetInt (((VitalName) i).ToString() + " - EXP To Level", pcClass.getVital(i).ExpToLevel);

			PlayerPrefs.SetString (((VitalName) i).ToString() + "Mods", pcClass.getVital(i).getModifiyingAttributeString());
		}

		for(int i = 0; i < Enum.GetValues (typeof(SkillName)).Length; i++)
		{
			PlayerPrefs.SetString (((SkillName) i).ToString() + " - Known", pcClass.getSkill(i).Known.ToString());
			PlayerPrefs.SetInt (((SkillName) i).ToString() + " - EXP To Level", pcClass.getSkill(i).ExpToLevel);

			PlayerPrefs.SetString (((SkillName) i).ToString() + "Mods", pcClass.getSkill(i).getModifiyingAttributeString());
		}
	}

	public void LoadCharacterData()
	{

	}
}
