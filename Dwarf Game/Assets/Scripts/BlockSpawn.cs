using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public float maxSpawnRate;
    public float minSpawnRate;
    public int rateOfFuelSpawn; //how many spawns happen until a fuel spawns.
    public GameObject slowBlock, scoreBlock, energyBlock;

    private float dist;
    private float timer;
    private int spawnFuelCounter;
    private float timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        maxSpawnRate = 1f;
        minSpawnRate = .5f;
        spawnFuelCounter = 0;
        timer = 0;
        timeToSpawn = 2;
    }

    // Update is called once per frame
    void Update()
    {
        dist = player.transform.position.y - (2f * cam.orthographicSize);
        timer += Time.deltaTime;
        if(timer >= timeToSpawn)
        {
            SpawnBlocks();
        }
    }

    void SpawnBlocks()
    {
        spawnFuelCounter++;
        Instantiate(slowBlock, new Vector3(Random.Range(-7, 7), dist + Random.Range(-3, 3), 0), Quaternion.identity);
        Instantiate(scoreBlock, new Vector3(Random.Range(-7, 7), dist + Random.Range(-3, 3), 0), Quaternion.identity);
        if(spawnFuelCounter >= rateOfFuelSpawn)
        {
            Instantiate(energyBlock, new Vector3(Random.Range(-7, 7), dist + Random.Range(-3, 3), 0), Quaternion.identity);
            spawnFuelCounter = 0;
        }
        timeToSpawn = SetTimeToSpawn();
        timer = 0;

    }

    float SetTimeToSpawn()
    {
        return (float)(Random.Range(minSpawnRate, maxSpawnRate));
    }


}
