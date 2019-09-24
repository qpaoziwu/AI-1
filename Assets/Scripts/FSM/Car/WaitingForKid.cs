using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class WaitingForKid : StateBehaviour
{
    public GameObject timeMaster;
    public GameObject kid3;
    public float kidOffset;

    void OnEnable()
    {

        kidOffset = timeMaster.GetComponent<Timers>().kidOffset;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kid"))
        {
            
            timeMaster.GetComponent<Timers>().CarEmpty = false;
            //yield return new WaitForSeconds(2f);
            SendEvent("Loaded");
        }

    }


    private void SpawnKid()
    {
        if (timeMaster.GetComponent<Timers>().CarEmpty == false)
        {

            Vector3 spawnOffset = new Vector3(transform.position.x, transform.position.y, transform.position.z + kidOffset);
            Instantiate(kid3, spawnOffset, Quaternion.identity);
            timeMaster.GetComponent<Timers>().CarEmpty = true;
            SendEvent("Loaded");
        }
    }
}


