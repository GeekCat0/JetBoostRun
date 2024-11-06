using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate : MonoBehaviour
{
    public float maxSpeed = 150f;
    float speed = 20f;


    private void Start()
    {
        speed = Random.Range(10f, maxSpeed);
    }

    void Update()
    {
       transform.Rotate(0f,0f,speed * Time.deltaTime);
    }
}
