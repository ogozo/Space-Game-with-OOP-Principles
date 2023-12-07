using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    float zPos = 110;
    float xRange = 85;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int index = Random.Range(0, enemies.Length);
            Instantiate(enemies[index], GenerateSpawnPos(), enemies[index].transform.rotation);
        }
    }
    Vector3 GenerateSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), 0, zPos);
    }
}
