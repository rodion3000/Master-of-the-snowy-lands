using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Atribut_Text : MonoBehaviour
{
    public TextMeshProUGUI my_text;
    
  

    private void Update()
    {
        my_text.text = $"������� {PlayerRPG.LvlUp} " +
            $"\n �������������� \n ���� {PlayerRPG.GetCurrent(PlayerAttribute.Strength)} \t �������� {PlayerRPG.GetCurrent(PlayerAttribute.Agility)} \t ���� {PlayerRPG.GetCurrent(PlayerAttribute.Mana)}" +
            $"\n \n ������ \n ������� ��� {PlayerRPG.GetCurrent(PlayerAttribute.Sword_Fight)} \t �������� ����� {PlayerRPG.GetCurrent(PlayerAttribute.Bow)} \t ����� {PlayerRPG.GetCurrent(PlayerAttribute.Magic)}" +
            $"\n \n ��������� \n ����� ������ {PlayerRPG.GetCurrent(PlayerAttribute.LockPicking)} \t ������ ���� {PlayerRPG.GetCurrent(PlayerAttribute.Skinning)} " +
            $"\n \n ���� {PlayerRPG.Experience} \t ����.������� {PlayerRPG.ExperienceRequired} \t \n ���� �������� {PlayerRPG.ExperiencePoints}";
    }

} 
