using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public GameObject timeMaster;
    // Start is called before the first frame update
    void Start()
    { 
        speed = timeMaster.GetComponent<Timers>().carSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = timeMaster.GetComponent<Timers>().carSpeed;
        Vector3 dir = new Vector3(1f,0f,0f);
        transform.position += dir*Time.deltaTime*speed;
    }
}
