using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class CheckingDestination : StateBehaviour
{
	// Called when the state is enabled
	void OnEnable () {
		Debug.Log("Started *State*");
	}
 
	// Called when the state is disabled
	void OnDisable () {
		Debug.Log("Stopped *State*");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Pot")
        {
            if (gameObject.tag == "Sam")
            {
                SendEvent("CookingPot");
            }
        }
        if (collision.gameObject.tag == "Artifact")
        {
            if (gameObject.tag == "Gollum")
            {
                SendEvent("GotArtifact");
            }
        }
    }
}


