/// <summary>
/// Attribute.cs
/// Rob Greene
/// 10/04/2014
/// 
/// This is the class for all character attributes in game.
/// </summary>
public class Attribute : BaseStat
{
	new public const int STARTING_EXP_COST = 50;	// Override the value from the base class. Starting cost for attribute level up

	private string _name;							// The name of the attribute

	/// <summary>
	/// Initializes a new instance of the <see cref="Attribute"/> class.
	/// </summary>
	public Attribute()
	{
		_name = "";
		ExpToLevel = STARTING_EXP_COST;
		LevelModifier = 1.05f;
	}

	/// <summary>
	/// Gets or sets the _name of the Attribute.
	/// </summary>
	/// <value>The _name.</value>
	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}
}

/// <summary>
/// Enumeration giving all possible Attribute names.
/// </summary>
public enum AttributeName 
{
	Might,
	Constitution,
	Nimbleness,
	Speed,
	Concentration,
	Willpower,
	Charisma
}
