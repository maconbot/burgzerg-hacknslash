using System.Collections.Generic;

public class ModifiedStat : BaseStat 
{
	private List<ModifyingAttribute> _mods;		// a list of attributes that modify this stat
	private int _modValue;						// stores the amount added to the base value from the mods

	public ModifiedStat()
	{
		_mods = new List<ModifyingAttribute> ();
		_modValue = 0;
	}

	public void addModifier(ModifyingAttribute mod)
	{
		_mods.Add (mod);
	}

	public string getModifiyingAttributeString()
	{
		string temp;

		for(int i = 0; i < _mods.Count; i++)
		{
			UnityEngine.Debug.Log (_mods[i].attribute.Name);
		}
		return "";
	}

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

	public new int AdjustedBaseValue {
		get { return BaseValue + BuffValue + _modValue; }
	}

	public void update()
	{
		calculateModValue ();
	}
}

public struct ModifyingAttribute
{
	public Attribute attribute;
	public float ratio;

	public ModifyingAttribute(Attribute att, float rat)
	{
		attribute = att;
		ratio = rat;
	}
}