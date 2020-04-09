using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyFolder;
    private Dictionary<Health, Healthbar> Enemies;
    [SerializeField] private Transform SpawnFolder;
    [SerializeField] private FloatingHealthbar Prototype;

    void Start()
    {
        Enemies = new Dictionary<Health, Healthbar>();
    }

    void Update()
    {
        CheckForSpawn();
    }

    void CheckForSpawn()
    {
        foreach (Health Enemy in EnemyFolder.GetComponentsInChildren(typeof(Health)))
        {
            if (Enemies.ContainsKey(Enemy)) { return; }

            var healthBar = Instantiate(Prototype, SpawnFolder);
            Debug.Log("Spawning " + healthBar);
            healthBar.ToFollow = Enemy.transform;
            Enemies.Add(Enemy, healthBar);
        }
    }

    //TODO maybe make a spawn-event instead of checking all entities
}
