using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarSpawner : MonoBehaviour
{
    
    [SerializeField] private Transform EnemyFolder;
    private Dictionary<Enemy, Healthbar> Enemies;
    [SerializeField] private Transform SpawnFolder;
    [SerializeField] private FloatingHealthbar Prototype;

    public bool PlayerHealthbar;

    void Start()
    {
        if (PlayerHealthbar) { SpawnPlayerHealthbar();}

        Enemies = new Dictionary<Enemy, Healthbar>();
    }

    void Update()
    {
        CheckForSpawn();
    }

    void CheckForSpawn()
    {
        foreach (Enemy Enemy in EnemyFolder.GetComponentsInChildren(typeof(Enemy)))
        {
            if (Enemies.ContainsKey(Enemy)) { return; }

            var healthBar = Instantiate(Prototype, SpawnFolder);
            healthBar.ToFollow = Enemy.transform;
            Enemies.Add(Enemy, healthBar);
        }
    }

    void SpawnPlayerHealthbar()
    {
        var healthBar = Instantiate(Prototype, SpawnFolder);
        healthBar.ToFollow = FindObjectOfType<PlayerClass>().transform;
        //TODO make healthbar have a 'SetTarget' method where i also add an event to remove the healthbar were the target to die.
    }

    //TODO maybe make a spawn-event instead of checking all entities
}
