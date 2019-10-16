using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class Deciding : StateBehaviour
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
	void Update ()
    {
	    if(gameObject.tag == "Sam")
        {
            SendEvent("MoveToPlayer");
        }

        if (gameObject.tag == "Gollum")
        {
            if (gameObject.GetComponent<Gollum_Hunger>().hungry)
            {
                SendEvent("Hungry");
            }
            if (!gameObject.GetComponent<Gollum_Hunger>().hungry)
            {
                SendEvent("NotHungry");
            }
        }
    }
}


