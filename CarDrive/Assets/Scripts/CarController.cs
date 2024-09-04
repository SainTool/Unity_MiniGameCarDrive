using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarController : MonoBehaviour
{
    public bool gameOver = false;

    public float carSpeed = 5.0f;
    public UnityEvent Dead;
    private float sizeObject = 0.5f;
    private bool carClickLeft, carClickRight;

    private void Update()
    {
        if (carClickLeft && transform.localPosition.x > (-4.5f + sizeObject))
            transform.localPosition += -transform.right * carSpeed * Time.deltaTime;
        if (carClickRight && transform.localPosition.x < (4.5f - sizeObject))
            transform.localPosition += transform.right * carSpeed * Time.deltaTime;

    }
    public void moveLeft(bool click)
    {
        carClickLeft = click;
    }
    public void moveRight(bool click)
    {
        carClickRight = click;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            carClickLeft = false;
            carClickRight = false;
            gameOver = true;
            Dead?.Invoke();

        }

    }
}
