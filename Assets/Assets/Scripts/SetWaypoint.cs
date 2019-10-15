using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWaypoint : MonoBehaviour
{
    public GameObject Waypoint1;
    public GameObject Waypoint2;
    public GameObject CurrentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectWaypoint();
        PlaceWaypoint();
    }

    void SelectWaypoint()
    {
        if(Waypoint1 & Waypoint2 !=null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CurrentWaypoint = Waypoint1;
                print("Waypoint1 Selected");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CurrentWaypoint = Waypoint2;
                print("Waypoint2 Selected");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CurrentWaypoint = null;
                print("Cancel Selection");

            }
        }
        else { print("Waypoint not set in Inspector"); }


    }

    void PlaceWaypoint()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (CurrentWaypoint != null)
            {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    CurrentWaypoint.gameObject.transform.position = hit.point;
                    print(CurrentWaypoint.name + " position is now " + CurrentWaypoint.gameObject.transform.position);
                }
            }else print("No selected waypoint");
        }
        
    }

}
