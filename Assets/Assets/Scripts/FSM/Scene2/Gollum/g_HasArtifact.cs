using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class g_HasArtifact : StateBehaviour
{
    public TextToUI textObject;

    // Called when the state is enabled
    void OnEnable () {
        textObject.GetComponent<TextToUI>().SetText(textObject.g_artifact);
    }

    // Called when the state is disabled
    void OnDisable () {
		Debug.Log("Stopped *State*");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


