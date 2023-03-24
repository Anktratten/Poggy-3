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
    // Start is called before the first frame update
    void Start()
    {
        OnBecameVisible();
        InvokeRepeating("SpawnVehicle", 2, 0.0385f);
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
            InvokeRepeating("SpawnEpaCar", 3, 2.5f);
            spawnedEpa = true;
        }
        if (Random.Range(1, 10) == 1 && spawnedEpa == false)
        {
            int randomCar = Random.Range(1, 4);
            if (randomCar == 1)
            {
                spawnedObject = Instantiate(testCar, transform.position, Quaternion.identity, transform);
            }
            else if (randomCar == 2)
            {
                spawnedObject = Instantiate(testCar, transform.position, Quaternion.identity, transform);
            }
            else if (randomCar == 3)
            {
                spawnedObject = Instantiate(testCar, transform.position, Quaternion.identity, transform);
            }
            else if (randomCar == 4)
            {
                spawnedObject = Instantiate(testCar, transform.position, Quaternion.identity, transform);
            }
            spawnedObject.GetComponent<Vehicle>().directionInt = spawnedDirection;
        }
    }
    void SpawnEpa()
    {
        spawnedObject = Instantiate(EPA, transform.position, Quaternion.identity);
        spawnedObject.GetComponent<Vehicle>().directionInt = spawnedDirection;
    }
    void SpawnEpaCar()
    {
        spawnedObject = Instantiate(EPACar, transform.position, Quaternion.identity);
        spawnedObject.GetComponent<Vehicle>().directionInt = spawnedDirection;
    }
    private void OnBecameVisible()
    {
        InvokeRepeating("IncreaseTime", 0, 1);
    }
    private void OnBecameInvisible()
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
}
