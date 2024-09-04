using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float carSpeed = 5.0f;
    private CarController carControllerSc;
    public GameObject[] cars;
    public bool isRotate = true;

    private void Start()
    {
        int x = Random.Range(0, cars.Length);
        cars[x].SetActive(true);
        carControllerSc = GameObject.Find("Car").GetComponent<CarController>();
    }

    void Update()
    {
        transform.localPosition += -transform.forward * carSpeed * Time.deltaTime;
        if (carControllerSc.gameOver)
        {
            if (isRotate)
            {
                if (carSpeed > 0)
                    carSpeed -= 0.01f;
                else
                    carSpeed = 0f;
            }
            else
            {
                carSpeed = -10.0f;
            }
        }
        if (transform.localPosition.z < -7 || transform.localPosition.z > 95)
            Destroy(gameObject);

    }
}
