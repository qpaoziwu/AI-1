using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class g_Satisfied : StateBehaviour
{
    public TextToUI textObject;

    // Called when the state is enabled
    void OnEnable () {
        textObject.GetComponent<TextToUI>().SetText(textObject.g_bargaining);

    }

    // Called when the state is disabled
    void OnDisable () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


