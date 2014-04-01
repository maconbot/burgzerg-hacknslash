using UnityEngine;
using System.Collections;
using System;	// Access the enum class

public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int _level;
	private uint _freeExp;

	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;

	public void Awake()
	{
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;

		_primaryAttribute = new Attribute[Enum.GetValues (typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

		setupPrimaryAttributes ();
		setupVitals ();
		setupSkills ();
	}

	// Setters and getters
	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	public int Level
	{
		get { return _level; }
		set { _level = value; }
	}

	public uint FreeExp
	{
		get { return _freeExp; }
		set { _freeExp = value; }
	}

	public void addExp(uint exp)
	{
		_freeExp += exp;

		calculateLevel ();
	}

	// Take average of all of the player's skills and assign that as the player level
	public void calculateLevel()
	{

	}

	private void setupPrimaryAttributes()
	{
		for(int i = 0; i < _primaryAttribute.Length; i++)
		{
			_primaryAttribute[i] = new Attribute();
		}
	}

	private void setupVitals()
	{
		for(int i = 0; i < _vital.Length; i++)
		{
			_vital[i] = new Vital();
		}

		setupVitalModifiers ();
	}

	private void setupSkills()
	{
		for(int i = 0; i < _skill.Length; i++)
		{
			_skill[i] = new Skill();
		}
		setupSkillModifiers ();
	}

	public Attribute getPrimaryAttribute(int index)
	{
		return _primaryAttribute [index];
	}

	public Vital getVital(int index)
	{
		return _vital [index];
	}

	public Skill getSkill(int index)
	{
		return _skill [index];
	}

	private void setupVitalModifiers()
	{
		// Health
		getVital ((int)VitalName.Health).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Constitution), 0.5f));
		// Energy
		getVital ((int)VitalName.Energy).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Constitution), 1.0f));
		// Mana
		getVital ((int)VitalName.Mana).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Willpower), 1.0f));
	}

	private void setupSkillModifiers()
	{
		// Melee Offence
		getSkill ((int)SkillName.Melee_Offence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Might), 0.33f));
		getSkill ((int)SkillName.Melee_Offence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Nimbleness), 0.33f));
		// Melee Defence
		getSkill ((int)SkillName.Melee_Defence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Speed), 0.33f));
		getSkill ((int)SkillName.Melee_Defence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Constitution), 0.33f));
		// Magic Offence
		getSkill ((int)SkillName.Magic_Offence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
		getSkill ((int)SkillName.Magic_Offence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Willpower), 0.33f));
		// Magic Defence
		getSkill ((int)SkillName.Magic_Defence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
		getSkill ((int)SkillName.Magic_Defence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Willpower), 0.33f));
		// Ranged Offense
		getSkill ((int)SkillName.Ranged_Offence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
		getSkill ((int)SkillName.Ranged_Offence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Speed), 0.33f));
		// Ranged Defence
		getSkill ((int)SkillName.Ranged_Defence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Speed), 0.33f));
		getSkill ((int)SkillName.Ranged_Defence).addModifier (new ModifyingAttribute(getPrimaryAttribute((int)AttributeName.Nimbleness), 0.33f));
	}

	public void statUpdate()
	{
		for(int i = 0; i < _vital.Length; i++)
		{
			_vital[i].update();
		}

		for(int i = 0; i < _skill.Length; i++)
		{
			_skill[i].update ();
		}
	}
}
