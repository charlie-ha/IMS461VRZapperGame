using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    //[SerializeField] private Transform[] waypoints; // Set waypoints in the inspector
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool pingPong = true; // If false, loops instead
    [SerializeField] private bool timerMode = false;
    private int currentLocation = 0;
    private int direction = 1; // 1 = forward, -1 = backward
    //[SerializeField] private Transform waypointGroup;//access parent of the target location
    //private List<Transform> waypoints = new List<Transform>();//create a list of these child locations
    //
    //public GameObject[] targetLocations;//create a list of these child locations
    private List<Transform> targetLocations = new List<Transform>();
    void Start()
    {
        if (timerMode)
        {
            FindMoveLocations("TM_targetMoveLocation");
        }
        else
        {
            FindMoveLocations("targetMoveLocations");
        }
        //foreach (Transform child in waypointGroup)//take each locations of the child into the location
        //{
        //    waypoints.Add(child);
        //}
        currentLocation = Random.Range(0, targetLocations.Count);
    }

    void Update()
    {
        if (targetLocations.Count < 2) return;

        // Move towards current waypoint
        //Transform target = targetLocations[currentWaypoint].transform;
        transform.position = Vector3.MoveTowards(transform.position, targetLocations[currentLocation].transform.position, speed * Time.deltaTime);

        // If reached current waypoint
        if (Vector3.Distance(transform.position, targetLocations[currentLocation].transform.position) < 0.01f)
        {
            if (pingPong)
            {
                if (currentLocation == targetLocations.Count - 1)//if (currentWaypoint == waypoints.Count - 1)
                    direction = -1;//go back if there are no other way points
                else if (currentLocation == 0)
                    direction = 1;//go forward if there are more way points or end of line

                currentLocation += direction;
            }
            else
            {
                currentLocation = (currentLocation + 1) % targetLocations.Count;
            }
        }
    }
    private void FindMoveLocations(string tag)
    {
        GameObject[] movePoints = GameObject.FindGameObjectsWithTag(tag);
        targetLocations.Clear();

        foreach (GameObject point in movePoints)
        {
            targetLocations.Add(point.transform);
        }

        if (targetLocations.Count < 2)
        {
            Debug.LogWarning($"TargetMover: Not enough waypoints found with tag '{tag}' to move the target.");
        }
    }
}
