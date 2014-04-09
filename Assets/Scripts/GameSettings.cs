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

//			PlayerPrefs.SetString (((VitalName) i).ToString() + "Mods", pcClass.getVital(i).getModifiyingAttributeString());
		}

		for(int i = 0; i < Enum.GetValues (typeof(SkillName)).Length; i++)
		{
			PlayerPrefs.SetInt (((SkillName) i).ToString() + " - Base Value", pcClass.getSkill(i).BaseValue);
			PlayerPrefs.SetInt (((SkillName) i).ToString() + " - EXP To Level", pcClass.getSkill(i).ExpToLevel);

//			PlayerPrefs.SetString (((SkillName) i).ToString() + "Mods", pcClass.getSkill(i).getModifiyingAttributeString());
		}
	}

	public void LoadCharacterData()
	{
		GameObject pc = GameObject.Find ("pc");
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter> ();

		pcClass.Name = PlayerPrefs.GetString ("Player Name", "Name Me");

		Debug.Log (pcClass.Name);

		for(int i = 0; i < Enum.GetValues (typeof(AttributeName)).Length; i++)
		{
			pcClass.getPrimaryAttribute(i).BaseValue = PlayerPrefs.GetInt (((AttributeName) i).ToString() + " - Base Value", 0);
			pcClass.getPrimaryAttribute(i).ExpToLevel = PlayerPrefs.GetInt (((AttributeName) i).ToString() + " - EXP To Level", 0);
		}


		for(int i = 0; i < Enum.GetValues (typeof(VitalName)).Length; i++)
		{
			pcClass.getVital(i).BaseValue = PlayerPrefs.GetInt (((VitalName) i).ToString() + " - Base Value", 0);
			pcClass.getVital(i).ExpToLevel = PlayerPrefs.GetInt (((VitalName) i).ToString() + " - EXP To Level", 0);

			pcClass.getVital(i).update();

			pcClass.getVital(i).CurrentValue = PlayerPrefs.GetInt(((VitalName) i).ToString() + " - Current Value", 1);
		}


		for(int i = 0; i < Enum.GetValues (typeof(SkillName)).Length; i++)
		{
			pcClass.getSkill(i).BaseValue = PlayerPrefs.GetInt (((SkillName) i).ToString() + " - Base Value", 0);
			pcClass.getSkill(i).ExpToLevel = PlayerPrefs.GetInt (((SkillName) i).ToString() + " - EXP To Level", 0);
		}

		for(int i = 0; i < Enum.GetValues (typeof(SkillName)).Length; i++)
		{
			Debug.Log(((SkillName) i).ToString() + " : " + pcClass.getSkill (i).BaseValue + " - " + pcClass.getSkill(i).ExpToLevel);
		}
	}
}
