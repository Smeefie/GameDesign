using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;
using UnityEngine.EventSystems;

public class StatisticManager : MonoBehaviour
{
    void Start()
    {
        runtimeStats.Clear();
        abilityData = new List<AbilityDataModel>();
    }
    public List<AbilityDataModel> abilityData;
    public runtimeStatistics runtimeStats;
    // private SaveData saveData;
}
public class AbilityDataModel
{
    public Ability ability;
    public int used;
    public int killed;
    public int hit;
}
