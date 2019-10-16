using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class g_EatingButterfly : StateBehaviour
{
	// Called when the state is enabled
	void OnEnable () {
        EatButterfly();
    }
 
	// Called when the state is disabled
	void OnDisable () {
		Debug.Log("Stopped *State*");
	}
	
	// Update is called once per frame
	void Update () {
 
    }

    void EatButterfly()
    {
        Invoke("DoneEating", 2f);
    }
    void DoneEating()
    {
        gameObject.GetComponent<Gollum_Hunger>().hunger += 1;
        SendEvent("AteButterfly");
    }
}


