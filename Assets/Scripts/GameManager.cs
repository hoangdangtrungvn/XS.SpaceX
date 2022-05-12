using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    private void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay < maxSpawnDelay)
            return;

        SpawnEnemies();

        maxSpawnDelay = Random.Range(0.5f, 3f);
        curSpawnDelay = 0;
    }

    void SpawnEnemies()
    {
        int enemy = Random.Range(0, enemies.Length);
        int point = Random.Range(0, spawnPoints.Length);
        Instantiate(enemies[enemy], spawnPoints[point].position, spawnPoints[point].rotation);
    }
}
