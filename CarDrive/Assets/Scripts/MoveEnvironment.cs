using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnvironment : MonoBehaviour
{

    public float carSpeed = 5.0f;
    public float posEndCamView = -10f;
    public float posLastObj = 30f;
    private Vector3 newPos;
    private CarController carControllerSc;
    public bool isRotate = false;

    private void Start()
    {
        carControllerSc = GameObject.Find("Car").GetComponent<CarController>();
        newPos= transform.localPosition;
    }
    void Update()
    {
        
        var bounds = GetComponent<MeshFilter>().sharedMesh.bounds;
        Vector3 vec = new Vector3(0, 0, 0);
        transform.position += -transform.forward * carSpeed * Time.deltaTime;
        if (carControllerSc.gameOver)
        {
            if (isRotate)
            {
                if (carSpeed < 0)
                    carSpeed += 0.01f;
                else
                    carSpeed = 0;
            }
            else
            {
                if (carSpeed > 0)
                    carSpeed -= 0.01f;
                else
                    carSpeed = 0;
            }
            
        }
        if (transform.position.z < posEndCamView) {
            newPos.z = posLastObj;
            newPos.y = 0f;
            transform.position = newPos;
                }
    }
}
