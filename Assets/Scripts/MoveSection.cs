using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveSection : MonoBehaviour
{
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameRunning)
        {
            transform.position += new Vector3(0, 0, -FindObjectOfType<GameManager>().gameSpeed) * Time.deltaTime;
        }
 
    }
}
