using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawnScript : MonoBehaviour
{
    private float yCoordinate = 10f;
    private float x;
    float spawnRate;
    private float nextSpawn = 0f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = Random.Range(5f, 10f);
        if (Time.time > nextSpawn)
        {
            x = Random.Range(-7f, 7f);
            Instantiate(prefab, new Vector3(x, yCoordinate, 0f), Quaternion.identity);
            nextSpawn = Time.time + spawnRate;

        }
    }
}
