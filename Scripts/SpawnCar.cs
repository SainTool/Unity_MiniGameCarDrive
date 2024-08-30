using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject[] spawnPos;
    public GameObject carPrefab;
    public bool isRotate = false;
    
    public float timeCarSpawn = 0.6f;
    private float startTimeCarSpawn;
    private CarController carControllerSc;
    void Start()
    {
        carControllerSc = GameObject.Find("Car").GetComponent<CarController>();
        startTimeCarSpawn = timeCarSpawn;
    }
    private void Update()
    {
        if(timeCarSpawn <= 0 && (!carControllerSc.gameOver || isRotate))
        {
            int x = Random.Range(0, spawnPos.Length);
            Instantiate(carPrefab, spawnPos[x].transform.position, Quaternion.identity);
            timeCarSpawn = startTimeCarSpawn;
        }
        else
        {
            timeCarSpawn -= Time.deltaTime;
        }
    }
}
