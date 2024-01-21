/**************************************************************************/
/** 	© 2016 NULLcode Studio. License: CC 0.
/** 	Разработано специально для http://null-code.ru/
/** 	WebMoney: R209469863836. Z126797238132, E274925448496, U157628274347
/** 	Яндекс.Деньги: 410011769316504
/**************************************************************************/

#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(PlayerSetup))]

public class PlayerSetupEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		PlayerSetup e = (PlayerSetup)target;
		GUILayout.Label("Генерировать Enum:", EditorStyles.boldLabel);
		if(GUILayout.Button("Create / Update"))
		{
			e.CreateInEditor();
		}
	}
}

public static class EnumGenerator
{
	public static void Go(string filePath, string[] list)
	{
		using(StreamWriter streamWriter = new StreamWriter(filePath + "/PlayerAttribute.cs"))
		{
			streamWriter.WriteLine("// Enum Generator: " + list.Length + " elements");
			streamWriter.WriteLine("// Внимание! Не редактировать вручную!");
			streamWriter.WriteLine("");
			streamWriter.WriteLine("public enum PlayerAttribute");
			streamWriter.WriteLine("{");
			for(int i = 0; i < list.Length; i++)
			{
				streamWriter.WriteLine("\t" + list[i] + ",");
			}
			streamWriter.WriteLine("}");
		}
		AssetDatabase.Refresh();
	}
}
#endif
