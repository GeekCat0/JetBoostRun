using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
