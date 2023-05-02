using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    int time;
    public int spawnedDirection;
    public GameObject testCar;
    GameObject spawnedObject;
    public GameObject EPA;
    public GameObject EPACar;
    public int timeToEpa;
    public bool spawnedEpa;

    public GameObject[] cars;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnVehicle", 2, 3);
        timeToEpa = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnVehicle()
    {
        if (time >= timeToEpa && spawnedEpa == false)
        {
            SpawnEpa();
            InvokeRepeating("SpawnEpaCar", 3, 1);
            spawnedEpa = true;
        }
        if (Random.Range(1, 2) == 1 && spawnedEpa == false)
        {
            SpawnCar();
        }
    }
    void SpawnEpa()
    {
        spawnedObject = Instantiate(EPA, transform.position, Quaternion.identity);
        spawnedObject.GetComponent<Vehicle>().directionInt = spawnedDirection;
        SetRotation();
    }
    void SpawnCar()
    {
        int randomCar = Random.Range(0, 3);
        spawnedObject = Instantiate(cars[randomCar], transform.position, Quaternion.identity);
        spawnedObject.GetComponent<Vehicle>().directionInt = spawnedDirection;
        SetRotation();
    }
    void SpawnEpaCar()
    {
        spawnedObject = Instantiate(EPACar, transform.position, Quaternion.identity);
        spawnedObject.GetComponent<Vehicle>().directionInt = spawnedDirection;
        SetRotation();
    }
    public void EnableSpawner()
    {
        InvokeRepeating("IncreaseTime", 0, 1);
    }
    public void DisableSpawner()
    {
        ResetTime();
        spawnedEpa = false;
    }
    void IncreaseTime()
    {
        time++;
    }
    void ResetTime()
    {
        time = 0;
    }
    void SetRotation()
    {
        if (spawnedDirection == 1)
        {
            spawnedObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
