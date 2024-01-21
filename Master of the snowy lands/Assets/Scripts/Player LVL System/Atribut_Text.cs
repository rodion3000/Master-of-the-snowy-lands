using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Atribut_Text : MonoBehaviour
{
    public TextMeshProUGUI my_text;
    
  

    private void Update()
    {
        my_text.text = $"Уровень {PlayerRPG.LvlUp} " +
            $"\n Характеристики \n Сила {PlayerRPG.GetCurrent(PlayerAttribute.Strength)} \t Ловкость {PlayerRPG.GetCurrent(PlayerAttribute.Agility)} \t Мана {PlayerRPG.GetCurrent(PlayerAttribute.Mana)}" +
            $"\n \n Навыки \n Ближний бой {PlayerRPG.GetCurrent(PlayerAttribute.Sword_Fight)} \t Владение луком {PlayerRPG.GetCurrent(PlayerAttribute.Bow)} \t Магия {PlayerRPG.GetCurrent(PlayerAttribute.Magic)}" +
            $"\n \n Профессии \n Взлом замков {PlayerRPG.GetCurrent(PlayerAttribute.LockPicking)} \t Снятие шкур {PlayerRPG.GetCurrent(PlayerAttribute.Skinning)} " +
            $"\n \n Опыт {PlayerRPG.Experience} \t След.Уровень {PlayerRPG.ExperienceRequired} \t \n Очки обучения {PlayerRPG.ExperiencePoints}";
    }

} 
