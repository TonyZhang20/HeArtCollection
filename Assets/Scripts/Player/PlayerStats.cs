using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    public PlayerStats_SO playerStats;
    public float maxHealth { get => playerStats?.maxHealth ?? 0; set => playerStats.maxHealth = value; }
    public float currentHealth { get => playerStats?.health ?? 0; set => playerStats.health = value; }
    public float Money { get => playerStats?.Money ?? 0; set => playerStats.Money = value; }

    // public string GUID => GetComponent<DataGUID>().guid;

    private void OnEnable() 
    {
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
    }

    private void OnDisable() 
    {
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
    }

    private void OnStartNewGameEvent(int obj)
    {
        currentHealth = Settings.maxHealth;
        maxHealth = currentHealth;
        Money = Settings.Money;
    }
}
