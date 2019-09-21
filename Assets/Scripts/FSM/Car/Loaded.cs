using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class Loaded : StateBehaviour
{

    public Transform destination;
    public Transform SpawnPoint;
    public Transform DropoffPoint;
    public Transform nextPoint;

    public bool travelDirection;
    public Vector3 dir;
    public float kidOffset;
    public float speed;
    public float positionThreshold;
    public GameObject timeMaster;
    public GameObject kid3;

    void OnEnable()
    {
        nextPoint = DropoffPoint;
        
        kidOffset = timeMaster.GetComponent<Timers>().kidOffset;
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
        Move(TravelDir(), NextDestination());
        CheckDestination(NextDestination());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Red") || collision.gameObject.CompareTag("Player"))
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
    public Transform NextDestination()
    {
        if (nextPoint = destination)
        {
            return destination;
        }
        if(nextPoint = DropoffPoint)
        {
            return DropoffPoint;
        }
        if ((nextPoint= DropoffPoint)&& timeMaster.GetComponent<Timers>().CarEmpty == false)
        {
            return DropoffPoint;
        }
        if ((nextPoint = DropoffPoint) && timeMaster.GetComponent<Timers>().CarEmpty == true)
        {
            return destination;
        } 


    return DropoffPoint;

    }

    private void CheckDestination(Transform t)
    {
        if (Vector3.Distance(transform.position, t.position) <= positionThreshold)
        {
          
            if ((nextPoint = DropoffPoint) &&timeMaster.GetComponent<Timers>().CarEmpty == false)
            {
                Debug.Log("Dropoff Kid");
                
                Vector3 spawnOffset = new Vector3(transform.position.x, transform.position.y, transform.position.z + kidOffset);
                Instantiate(kid3, spawnOffset, Quaternion.identity);
                timeMaster.GetComponent<Timers>().CarEmpty = true;
            }

            if (nextPoint = destination)
            {
                SendEvent("Despawn");
            }
        }
    }
}


