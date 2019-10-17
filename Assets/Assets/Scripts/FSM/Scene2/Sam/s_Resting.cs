using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class s_Resting : StateBehaviour
{
    public GameObject Pot;

    public TextToUI textObject;


    // Called when the state is enabled
    void OnEnable () {
        gameObject.transform.position = Pot.transform.position;
        gameObject.transform.rotation = Pot.transform.rotation;
        textObject = textObject.GetComponent<TextToUI>();
        textObject.SetText(textObject.s_resting);
    }
 
	// Called when the state is disabled
	void OnDisable () {

	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Pot.transform.position;
        gameObject.transform.rotation = Pot.transform.rotation;

    }
}


