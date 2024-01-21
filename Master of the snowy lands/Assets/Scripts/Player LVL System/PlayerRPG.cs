/**************************************************************************/
/** 	© 2016 NULLcode Studio. License: CC 0.
/** 	Разработано специально для http://null-code.ru/
/** 	WebMoney: R209469863836. Z126797238132, E274925448496, U157628274347
/** 	Яндекс.Деньги: 410011769316504
/**************************************************************************/

using UnityEngine;
using System.Collections;

public delegate void EventAdjust(string attribute);
public delegate void EventAttribute(string attribute);
public delegate void EventExperience();

public static class PlayerRPG {

	public static event EventAdjust OnValueChange;
	public static event EventAttribute OnAttributeChange;
	public static event EventExperience OnExperience;
	private static Attributes[] _attributes;
	private static int expRequired, experience, expPointsCur, expPoints, _Lvl;
	private static float expMultiplier;

	public static int ExperiencePoints // очки прокачки
	{
		get{ return expPointsCur; }
	}

	public static int Experience // текущий опыт
	{
		get{ return experience; }
	}

	public static int ExperienceRequired // требуемый опыт, для повышения уровня
	{
		get{ return expRequired; }
	}
	public static int LvlUp // Уровень
	{
		get { return _Lvl; }
	}

	// прокачка атрибута, при которой происходит трата очков прокачки
	// повышение происходит на один уровень, списывается один балл
	public static void AddLevelAttribute(PlayerAttribute attribute)
	{
		if(expPointsCur == 0 || _attributes[(int)attribute].value == _attributes[(int)attribute].valueMax) return;
		expPointsCur--;
		AdjustCurrentValue(1, attribute);
	}

	// изменение текущего опыта и добавление очков прокачки и поднятие лвл
	// добавление происходит без потерь
	public static void AdjustExperience(int value)
	{
		experience += value;
		if(experience < 0) experience = 0;
		if(experience >= expRequired)
		{
			_Lvl += 1;
			int j = experience - expRequired;
			experience = (j > 0) ? j : 0;
			float ex = expRequired * expMultiplier;
			expRequired = (int)ex;
			expPointsCur += expPoints;
			if(OnExperience != null) OnExperience();
		}
	}

	// изменение настроек атрибута, например
	// если получен некий перк, который допустим, расширяет максимальное значение
	public static void ChangeAttributeSettings(int min, int max, PlayerAttribute attribute)
	{
		if(!IsLoaded() || min > max) return;
		int i = (int)attribute;
		_attributes[i].valueMin = min;
		_attributes[i].valueMax = max;
		if(OnAttributeChange != null) OnAttributeChange(attribute.ToString());
	}

	// изменение текущего значения атрибута (без учета текущих очков прокачки)
	public static void AdjustCurrentValue(int current, PlayerAttribute attribute)
	{
		if(!IsLoaded()) return;
		int i = (int)attribute;
		int cur = _attributes[i].value;
		int min = _attributes[i].valueMin;
		int max = _attributes[i].valueMax;
		if(cur == max && cur + current > max || cur == min && cur + current < min) return;
		cur += current;
		if(cur > max) cur = max;
		if(cur < min) cur = min;
		_attributes[i].value = cur;
		if(OnValueChange != null) OnValueChange(attribute.ToString());
	}

	public static int GetCurrent(PlayerAttribute attribute) // запрос текущего значения атрибута
	{
		return (IsLoaded()) ? _attributes[(int)attribute].value : 0;
	}

	public static int GetMax(PlayerAttribute attribute) // запрос максимального значения атрибута
	{
		return (IsLoaded()) ? _attributes[(int)attribute].valueMax : 0;
	}

	public static int GetMin(PlayerAttribute attribute) // запрос минимального значения атрибута
	{
		return (IsLoaded()) ? _attributes[(int)attribute].valueMin : 0;
	}

	static bool IsLoaded()
	{
		if(_attributes != null) return true;
		return false;
	}

	public static void Initialize(Attributes[] attributes, float eMultiplier, int eRequired, int ePoints, int Lvl)
	{
		expPoints = ePoints;
		expMultiplier = eMultiplier;
		if(!IsLoaded()) Load(attributes.Length);
		if(!IsLoaded())
		{
			experience = 0;
			expPointsCur = 0;
			expRequired = eRequired;
			_attributes = attributes;
			_Lvl = Lvl;
		}
	}

	public static void Save()
	{
		string vCur = string.Empty, vMax = string.Empty, vMin = string.Empty;

		for(int i = 0; i < _attributes.Length; i++)
		{
			if(i > 0)
			{
				vCur += "|";
				vMax += "|";
				vMin += "|";
			}

			vCur += _attributes[i].value.ToString();
			vMax += _attributes[i].valueMax.ToString();
			vMin += _attributes[i].valueMin.ToString();
		}

		PlayerPrefs.SetString("AVCur", vCur);
		PlayerPrefs.SetString("AVMax", vMax);
		PlayerPrefs.SetString("AVMin", vMin);
		PlayerPrefs.SetInt("Exp", experience);
		PlayerPrefs.SetInt("ExpR", expRequired);
		PlayerPrefs.SetInt("ExpP", expPointsCur);
		PlayerPrefs.SetInt("Lvl", _Lvl);
		PlayerPrefs.Save();
		Debug.Log("PlayerRPG : сохранение прогресса.");
	}

	static void Load(int count)
	{
		if(!PlayerPrefs.HasKey("Exp")) return;

		string[] vCur = PlayerPrefs.GetString("AVCur").Split(new char[]{'|'});
		string[] vMax = PlayerPrefs.GetString("AVMax").Split(new char[]{'|'});
		string[] vMin = PlayerPrefs.GetString("AVMin").Split(new char[]{'|'});

		experience = PlayerPrefs.GetInt("Exp");
		expRequired = PlayerPrefs.GetInt("ExpR");
		expPointsCur = PlayerPrefs.GetInt("ExpP");
		_Lvl = PlayerPrefs.GetInt("Lvl");

		_attributes = new Attributes[count];

		for(int i = 0; i < _attributes.Length; i++)
		{
			_attributes[i].value = int.Parse(vCur[i]);
			_attributes[i].valueMax = int.Parse(vMax[i]);
			_attributes[i].valueMin = int.Parse(vMin[i]);
		}
	}

	[System.Serializable] public struct Attributes
	{
		public string name;
		public int value;
		public int valueMax;
		public int valueMin;
	}

}
