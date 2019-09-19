using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class Obstructed : StateBehaviour
{

    // Called when the state is enabled
    void OnEnable () {


        Debug.Log("Blocked");
	}
 
	// Called when the state is disabled
	void OnDisable () {
		Debug.Log("Stopped *State*");
	}
	
	// Update is called once per frame
	void Update () {
        //SendEvent("Cleared");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Green")
        {
            Debug.Log("Cleared");

            SendEvent("Cleared");
        }
    }

}


