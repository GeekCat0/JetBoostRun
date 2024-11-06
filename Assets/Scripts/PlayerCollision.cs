using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool godMode = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Killer") && !godMode)
        {
            Object.FindFirstObjectByType<GameManager>().EndGame();
        }
        if (other.gameObject.CompareTag("Sensor"))
        {
            other.GetComponentInParent<DoorsScript>().activated = true;
        }
        if (other.gameObject.CompareTag("Sensor2"))
        {
            other.GetComponentInParent<DoorsScript1>().activated = true;
        }
        if (other.gameObject.CompareTag("Spikes"))
        {
            other.GetComponentInParent<SpikeTrap>().activated = true;
        }
    }

}
