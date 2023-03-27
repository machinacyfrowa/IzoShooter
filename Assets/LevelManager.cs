using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject zombiePefab;
    public GameObject healPrefab;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < 3) 
        {
            Instantiate(zombiePefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
        if (GameObject.FindGameObjectsWithTag("Heal").Length < 1)
        {
            Instantiate(healPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPoint;
        do
        {
            spawnPoint = UnityEngine.Random.insideUnitSphere;
            spawnPoint.y = 0f;
            spawnPoint = spawnPoint.normalized;
            spawnPoint *= UnityEngine.Random.Range(10f, 20f);
            spawnPoint += player.transform.position;
        }
        //TODO: check this shit
        while (Physics.CheckSphere(new Vector3(spawnPoint.x, 1, spawnPoint.z), 0.9f));

        return spawnPoint;
    }
}
