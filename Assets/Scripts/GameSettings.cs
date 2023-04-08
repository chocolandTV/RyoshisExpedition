using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSetting",menuName = "ScriptableObjects/GameSetting", order = 1)]
public class GameSettings : ScriptableObject
{
   public GameObject[] spawningObjectsList = new GameObject[10];
   [Range(0,100)]
   public int[] blockChance = new int[10];
   public float ObjectSpeed;
   [Range(0,100)]
   public int EnergyChance;
   
}
