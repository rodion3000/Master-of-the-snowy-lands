// тест системы

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZTest : MonoBehaviour {

	public Text text;
	public Text textEvent;

	void Awake()
	{
		// подписка на нужные события
		PlayerRPG.OnAttributeChange += EventAttributeChange;
		PlayerRPG.OnValueChange += EventValueChange;
		PlayerRPG.OnExperience += EventExperience;
	}

	void OnDestroy()
	{
		// отписываемся, при переходе на другую сцену или когда объект уничтожен (обязательно)
		PlayerRPG.OnAttributeChange -= EventAttributeChange;
		PlayerRPG.OnValueChange -= EventValueChange;
		PlayerRPG.OnExperience -= EventExperience;
	}

	void EventAttributeChange(string attribute)
	{
		SetLog("Cобытие: изменение настроек атрибута [" + attribute + "]");
	}

	void EventValueChange(string attribute)
	{
		SetLog("Cобытие: изменение текущего значения атрибута [" + attribute + "]");
	}

	public void EventExperience()
	{
		SetLog("Cобытие: повышение уровня персонажа.");
		
	}

	void SetLog(string t)
	{
		textEvent.text = t;
		Debug.Log(t);
	}

	void LateUpdate()
	{
		text.text = "Прогресс опыта: " + PlayerRPG.Experience + " / " + PlayerRPG.ExperienceRequired + "\n\n" +
			"Выдано очков прокачки: " + PlayerRPG.ExperiencePoints + "\n\n" +
			"Состояние атрибута [" + PlayerAttribute.Agility + "]: current = " + PlayerRPG.GetCurrent(PlayerAttribute.Agility) + " / " +
			"max = " + PlayerRPG.GetMax(PlayerAttribute.Agility) + " / min = " + PlayerRPG.GetMin(PlayerAttribute.Agility);
	}

	public void TestAdjustCurrentValue(int val)
	{
		PlayerRPG.AdjustCurrentValue(val, PlayerAttribute.Agility);
	}

	public void TestChangeAttributeSettings()
	{
		PlayerRPG.ChangeAttributeSettings(4, 18, PlayerAttribute.Agility);
	}

	public void TestSave()
	{
		PlayerRPG.Save();
	}

	public void TestAdjustExperience(int val)
	{
		PlayerRPG.AdjustExperience(val);
	}

	public void TestAddLevelAttribute()
	{
		PlayerRPG.AddLevelAttribute(PlayerAttribute.Agility);
	}
}
