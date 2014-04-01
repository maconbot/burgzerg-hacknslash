using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour {
	private PlayerCharacter _toon;
	private const int STARTING_POINTS = 350;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
	private const int STARTING_VALUE = 50;
	private int pointsLeft;

	private const int OFFSET = 5;
	private const int LINE_HEIGHT = 20;

	private const int STAT_LABEL_WIDTH = 100;
	private const int BASEVALUE_LABEL_WIDTH = 30;

	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;

	private int statStartingPos = 40;

	// Use this for initialization
	void Start () {
		_toon = new PlayerCharacter ();
		_toon.Awake ();

		pointsLeft = STARTING_POINTS;

		for(int i = 0; i < Enum.GetValues (typeof(AttributeName)).Length; i++)
		{
			_toon.getPrimaryAttribute(i).BaseValue = STARTING_VALUE;
			pointsLeft -= (STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE);
		}

		_toon.statUpdate ();

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI()
	{
		displayName ();
		displayPointsLeft ();
		displayAttributes ();
		displayVitals ();
		displaySkills ();
	}

	private void displayName()
	{
		GUI.Label (new Rect(10, 10, 50, 25), "Name:");
		_toon.Name = GUI.TextField (new Rect (65, 10, 100, 25), _toon.Name);
	}

	private void displayPointsLeft()
	{
		GUI.Label (new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft.ToString());
	}

	private void displayAttributes()
	{
		for(int i = 0; i < Enum.GetValues (typeof(AttributeName)).Length; i++)
		{
			GUI.Label (new Rect(OFFSET, statStartingPos + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((AttributeName) i).ToString());
			GUI.Label (new Rect(STAT_LABEL_WIDTH + OFFSET, statStartingPos + (i * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), 
			           _toon.getPrimaryAttribute(i).AdjustedBaseValue.ToString());
			if(GUI.Button (new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + OFFSET, statStartingPos + (i * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "-"))
			{
				if(_toon.getPrimaryAttribute(i).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE)
				{
					_toon.getPrimaryAttribute(i).BaseValue--;
					pointsLeft++;
					_toon.statUpdate ();
				}
			}
			if(GUI.Button (new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH, statStartingPos + (i * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "+"))
			{
				if(pointsLeft > 0)
				{
					_toon.getPrimaryAttribute(i).BaseValue++;
					pointsLeft--;
					_toon.statUpdate ();
				}
			}
		}
	}

	private void displayVitals()
	{
		for(int i = 0; i < Enum.GetValues (typeof(VitalName)).Length; i++)
		{
			GUI.Label (new Rect(OFFSET, statStartingPos + ((i + 7) * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((VitalName) i).ToString());
			GUI.Label (new Rect(STAT_LABEL_WIDTH + OFFSET, statStartingPos + ((i + 7) * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), 
			           _toon.getVital(i).AdjustedBaseValue.ToString());
		}
	}

	private void displaySkills()
	{
		for(int i = 0; i < Enum.GetValues (typeof(SkillName)).Length; i++)
		{
			GUI.Label (new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH*2 + OFFSET*2, statStartingPos + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((SkillName) i).ToString());
			GUI.Label (new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH*2 + OFFSET*2 + STAT_LABEL_WIDTH, statStartingPos + (i * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), _toon.getSkill(i).AdjustedBaseValue.ToString());
		}
	}
}
