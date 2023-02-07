using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int HealthValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>()) 
        {
            other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(HealthValue);
            Destroy(gameObject);
        }
    }
}
