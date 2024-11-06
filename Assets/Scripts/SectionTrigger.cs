using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] roadSection;
    public GameObject trigger;

    public void Start()
    {
        int choice = Random.Range(0, roadSection.Length);
        Instantiate(trigger, new Vector3(0, 0, 44), Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            int choice = Random.Range(0, roadSection.Length);
            Instantiate(trigger, new Vector3(-6.3f, 7.4f, 220), Quaternion.identity);
            Instantiate(roadSection[choice], new Vector3(0, 0, 220), Quaternion.identity);
            choice = Random.Range(0, roadSection.Length);
            Instantiate(roadSection[choice], new Vector3(0, 0, 264), Quaternion.identity);
            choice = Random.Range(0, roadSection.Length);
            Instantiate(roadSection[choice], new Vector3(0, 0, 308), Quaternion.identity);
            choice = Random.Range(0, roadSection.Length);
            Instantiate(roadSection[choice], new Vector3(0, 0, 352), Quaternion.identity);
            choice = Random.Range(0, roadSection.Length);
            Instantiate(roadSection[choice], new Vector3(0, 0, 396), Quaternion.identity);
        }
    }
}
