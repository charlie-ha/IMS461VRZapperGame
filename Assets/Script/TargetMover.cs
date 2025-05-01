using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    //[SerializeField] private Transform[] waypoints; // Set waypoints in the inspector
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool pingPong = true; // If false, loops instead

    private int currentWaypoint = 0;
    private int direction = 1; // 1 = forward, -1 = backward
    //[SerializeField] private Transform waypointGroup;//access parent of the target location
    //private List<Transform> waypoints = new List<Transform>();//create a list of these child locations
    public GameObject[] targetLocations;//create a list of these child locations
    void Start()
    {
        targetLocations = GameObject.FindGameObjectsWithTag("targetMoveLocations");
        //foreach (Transform child in waypointGroup)//take each locations of the child into the location
        //{
        //    waypoints.Add(child);
        //}
        currentWaypoint = Random.Range(0, targetLocations.Length);
    }

    void Update()
    {
        if (targetLocations.Length < 2) return;

        // Move towards current waypoint
        //Transform target = targetLocations[currentWaypoint].transform;
        transform.position = Vector3.MoveTowards(transform.position, targetLocations[currentWaypoint].transform.position, speed * Time.deltaTime);

        // If reached current waypoint
        if (Vector3.Distance(transform.position, targetLocations[currentWaypoint].transform.position) < 0.01f)
        {
            if (pingPong)
            {
                if (currentWaypoint == targetLocations.Length - 1)//if (currentWaypoint == waypoints.Count - 1)
                    direction = -1;//go back if there are no other way points
                else if (currentWaypoint == 0)
                    direction = 1;//go forward if there are more way points or end of line

                currentWaypoint += direction;
            }
            else
            {
                currentWaypoint = (currentWaypoint + 1) % targetLocations.Length;
            }
        }
    }
}
