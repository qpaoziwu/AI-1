using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidDespawn : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        { 
            Destroy(this.gameObject);
        }
    }
}
