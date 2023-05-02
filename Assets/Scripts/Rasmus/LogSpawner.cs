using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public int spawnDirection;
    public GameObject[] logs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLog", 2, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnLog()
    {
        if (Random.Range(1, 2) == 1)
        {
            GameObject spawnedLog = Instantiate(logs[Random.Range(0,3)], transform.position, Quaternion.identity);
            spawnedLog.GetComponent<Log>().directionInt = spawnDirection;
        }
    }
}
