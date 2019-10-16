using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class s_Resting : StateBehaviour
{
    public GameObject Pot;

    // Called when the state is enabled
    void OnEnable () {
        gameObject.transform.position = Pot.transform.position;
        gameObject.transform.rotation = Pot.transform.rotation;


        Debug.Log("Started *State*");
	}
 
	// Called when the state is disabled
	void OnDisable () {
		Debug.Log("Stopped *State*");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Pot.transform.position;
        gameObject.transform.rotation = Pot.transform.rotation;
    }
}


