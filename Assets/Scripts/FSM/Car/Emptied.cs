using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class Emptied : StateBehaviour
{
    public Transform destination;
    public Transform SpawnPoint;
    public Transform DropoffPoint;

    public bool travelDirection;
    public Vector3 dir;
    public float speed;
    public float positionThreshold;
    public GameObject timeMaster;

    void OnEnable()
    {

        speed = timeMaster.GetComponent<Timers>().carSpeed;
        positionThreshold = timeMaster.GetComponent<Timers>().carDespawnThreshold;
    }

    // Called when the state is disabled
    void OnDisable()
    {
        Debug.Log("Stopped *State*");
    }

    // Update is called once per frame
    void Update()
    {
        Move(TravelDir(), destination);
        CheckDestination(destination);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            Debug.Log("Hit");
            SendEvent("Blocked");
        }

    }
    public float TravelDir()
    {
        if (dir.x >= 0)
        {
            return 1;
        }
        else return -1;
    }
    private void Move(float dirModifier, Transform destination)
    {

        Vector3 dir = Vector3.Normalize(destination.position - transform.position);
        Vector3 lerpDir = Vector3.Slerp(transform.position, dir, 4f);
        speed = timeMaster.GetComponent<Timers>().carSpeed;

        transform.position += lerpDir * Time.deltaTime * speed * dirModifier;
        transform.rotation = Quaternion.LookRotation(lerpDir);

    }

    private void CheckDestination(Transform t)
    {
        if (Vector3.Distance(transform.position, t.position) <= positionThreshold)
        {
            SendEvent("Despawn");
        }
    }

}