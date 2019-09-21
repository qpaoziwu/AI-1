using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class WaitingForKid : StateBehaviour
{
    public GameObject timeMaster;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kid"))
        {
            //yield return new WaitForSeconds(1f);
            timeMaster.GetComponent<Timers>().CarEmpty = false;
            SendEvent("Loaded");
        }

    }
}


