using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public float maxSpawnRate;
    public float minSpawnRate;
    public GameObject slowBlock;

    private float dist;
    private float timer;
    private float timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        maxSpawnRate = 1f;
        minSpawnRate = .5f;
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
            Instantiate(slowBlock, new Vector3(Random.Range(-7, 7), dist, 0), Quaternion.identity);
            timeToSpawn = SetTimeToSpawn();
            timer = 0;
        }
    }

    float SetTimeToSpawn()
    {
        return (float)(Random.Range(minSpawnRate, maxSpawnRate));
    }
}
