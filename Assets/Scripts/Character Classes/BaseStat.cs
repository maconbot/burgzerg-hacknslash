/// <summary>
/// BaseStat.cs
/// Rob Greene
/// 10/04/2014
/// 
/// This is the base class for all stats in the game
/// </summary>

using UnityEngine;

public class BaseStat 
{
	public const int STARTING_EXP_COST = 100;	// publicly accessible value for all base stats to start at

	private int _baseValue;						// the base value of this stat
	private int _buffValue;						// the amount of the "buff" to this stat
	private int _expToLevel;					// the amount of exp needed to raise this skill
	private float _levelModifier;				// the modifier applied to the exp needed to raise the skill


	/// <summary>
	/// Initializes a new instance of the <see cref="BaseStat"/> class.
	/// </summary>
	public BaseStat()
	{
		_baseValue = 0;
		_buffValue = 0;
		_levelModifier = 1.1f;
		_expToLevel = STARTING_EXP_COST;
	}

#region Basic Setters and Getters
	/// <summary>
	/// Gets or sets the _baseValue.
	/// </summary>
	/// <value>The _baseValue.</value>
	public int BaseValue {
		get{ return _baseValue; }
		set{ _baseValue = value; }
	}

	/// <summary>
	/// Gets or sets the _buffValue.
	/// </summary>
	/// <value>The _buffValue.</value>
	public int BuffValue {
		get{ return _buffValue; }
		set{ _buffValue = value; }
	}

	/// <summary>
	/// Gets or sets the _expToLevel.
	/// </summary>
	/// <value>The _expToLevell.</value>
	public int ExpToLevel {
		get{ return _expToLevel; }
		set{ _expToLevel = value; }
	}

	/// <summary>
	/// Gets or sets the _levelModifier.
	/// </summary>
	/// <value>The _levelModifier.</value>
	public float LevelModifier {
		get{ return _levelModifier; }
		set{ _levelModifier = value; }
	}
#endregion

	/// <summary>
	/// Calculates the exp to level.
	/// </summary>
	/// <returns>The exp to level.</returns>
	private int calculateExpToLevel()
	{
		return (int) (_expToLevel * _levelModifier);
	}


	/// <summary>
	/// Levels up. Increases base value by one and recalculates exp to next level.
	/// </summary>
	public void levelUp()
	{
		_expToLevel = calculateExpToLevel ();
		_baseValue++;
	}

	/// <summary>
	/// Recalculate the adjusted base value and return it.
	/// </summary>
	/// <value>The adjusted base value.</value>
	public int AdjustedBaseValue	{
		get { return _baseValue + _buffValue; }
	}
}
