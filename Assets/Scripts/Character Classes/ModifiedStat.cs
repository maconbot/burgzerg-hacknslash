/// <summary>
/// ModifiedStat.cs
/// Rob Greene
/// 10/04/2014
/// 
/// This is the base class for all stats that will be modifiable by attributes
/// </summary>

using System.Collections.Generic;	// Generic was added so we can use the List<> class

public class ModifiedStat : BaseStat 
{
	private List<ModifyingAttribute> _mods;		// a list of attributes that modify this stat
	private int _modValue;						// stores the amount added to the base value from the mods

	/// <summary>
	/// Initializes a new instance of the <see cref="ModifiedStat"/> class.
	/// </summary>
	public ModifiedStat()
	{
		_mods = new List<ModifyingAttribute> ();
		_modValue = 0;
	}

	/// <summary>
	/// Add a modifier that will modify this stat.
	/// </summary>
	/// <param name="mod">The modifying attribute that affects this stat.</param>
	public void addModifier(ModifyingAttribute mod)
	{
		_mods.Add (mod);
	}

	/// <summary>
	/// Gets the modifiying attribute string which lists the attributes that modify this stat.
	/// </summary>
	/// <returns>The modifiying attribute string. Attributes are separated by | and values by _</returns>
	public string getModifiyingAttributeString()
	{
		string temp = "";

		for(int i = 0; i < _mods.Count; i++)
		{
			temp += _mods[i].attribute.Name;
			temp += "_";
			temp += _mods[i].ratio;

			if(i < _mods.Count - 1)
			{
				temp += "|";
			}
		}
		UnityEngine.Debug.Log (temp);
		return temp;
	}

	/// <summary>
	/// Calculates the mod value for each modifying attribute.
	/// </summary>
	private void calculateModValue()
	{
		_modValue = 0;

		if(_mods.Count > 0)
		{
			foreach(ModifyingAttribute ma in _mods)
			{
				_modValue += (int)(ma.attribute.AdjustedBaseValue * ma.ratio);
			}
		}
	}

	/// <summary>
	/// This function is overriding the AdjustedBaseValue in the BaseStat class.
	/// Recalculate the adjusted base value and return it. Take account of the modified value of the stat.
	/// </summary>
	/// <value>The adjusted base value.</value>
	public new int AdjustedBaseValue {
		get { return BaseValue + BuffValue + _modValue; }
	}

	/// <summary>
	/// Update the modified value of this stat.
	/// </summary>
	public void update()
	{
		calculateModValue ();
	}
}

/// <summary>
/// Modifying attribute that contains the attribute that modifies the stat and a ratio of how much
/// it modifies the stat.
/// </summary>
public struct ModifyingAttribute
{
	public Attribute attribute;		// The attribute that acts as a modifier
	public float ratio;				// The percentage of the Attribute's adjusted base value 
									// that will be applied to a ModifiedStat

	/// <summary>
	/// Initializes a new instance of the <see cref="ModifyingAttribute"/> struct.
	/// </summary>
	/// <param name="att">The attribute that will modify the ModifiedStat.</param>
	/// <param name="rat">The ratio of how much the Attribute .</param>
	public ModifyingAttribute(Attribute att, float rat)
	{
		attribute = att;
		ratio = rat;
	}
}