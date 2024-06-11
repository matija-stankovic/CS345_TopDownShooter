using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private List<Enemy> enemies = new List<Enemy>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        FindAllEnemies();
        Debug.Log("Initial enemy count: " + enemies.Count);
    }

    private void Update()
    {
        foreach(Enemy enemy in enemies)
        {
            if(enemy == null)
            {
                UnregisterEnemy(enemy);
            }
        }
    }

    void FindAllEnemies()
    {
        enemies.AddRange(FindObjectsOfType<Enemy>());
    }

    public void RegisterEnemy(Enemy enemy)
    {
        if (enemy != null && !enemies.Contains(enemy))
        {
            enemies.Add(enemy);
            Debug.Log("Enemy registered. Current enemy count: " + enemies.Count);
        }
    }

    public void UnregisterEnemy(Enemy enemy)
    {
        if (enemy == null && enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
            Debug.Log("Enemy unregistered. Current enemy count: " + enemies.Count);
            if (enemies.Count == 0)
            {
                AllEnemiesDefeated();
            }
        }
    }

    void AllEnemiesDefeated()
    {
        Debug.Log("All enemies defeated! You can now proceed to the goal.");
    }

    public bool AreAllEnemiesDefeated()
    {
        return enemies.Count == 0;
    }
}
