/**************************************************************************/
/** 	© 2016 NULLcode Studio. License: CC 0.
/** 	Разработано специально для http://null-code.ru/
/** 	WebMoney: R209469863836. Z126797238132, E274925448496, U157628274347
/** 	Яндекс.Деньги: 410011769316504
/**************************************************************************/

using UnityEngine;
using System.Collections;

public class PlayerSetup : MonoBehaviour {

	[Header("Редактирование атрибутов:")]
	[SerializeField] private PlayerRPG.Attributes[] attributes;
	[Header("Настройки опыта:")]
	[SerializeField] private int experienceRequired = 1000; // стартовое значение, если еще нет сохранений, по достижению которого, происходит повышение уровня
	[SerializeField] private float experienceMultiplier = 1.7f; // умножение требуемого значения, после повышения уровня
	[SerializeField] private int experiencePoints = 3; // сколько очков прокачки будет начисляться с повышением уровня
	[SerializeField] private int Lvl = 1; // стартовое значение уровня

	void Awake()
	{
		Initialize();
	}

	void Initialize()
	{
		PlayerRPG.Initialize(attributes, experienceMultiplier, experienceRequired, experiencePoints,Lvl);
	}

	#if UNITY_EDITOR
	public void CreateInEditor()
	{
		string filePath = "Assets/Scripts/Player LVL System"; // путь где в проекте лежит скрипт PlayerAttribute.cs
		string[] list = new string[attributes.Length];
		for(int i = 0; i < attributes.Length; i++)
		{
			list[i] = attributes[i].name;
		}
		EnumGenerator.Go(filePath, list);
		Debug.Log(this + " обновление класса 'PlayerAttribute'");
	}
	#endif
}
