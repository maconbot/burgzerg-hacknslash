public class Skill : ModifiedStat 
{
	private bool _known;

	public Skill()
	{
		_known = false;
		ExpToLevel = 25;
		LevelModifier = 1.1f;
	}

	// Setter and getter
	public bool Known {
		get { return _known; }
		set { _known = value; }
	}
}

public enum SkillName {
	Melee_Offence,
	Melee_Defence,
	Ranged_Offence,
	Ranged_Defence,
	Magic_Offence,
	Magic_Defence
}