using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Set waypoints in the inspector
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool pingPong = true; // If false, loops instead

    private int currentWaypointIndex = 0;
    private int direction = 1; // 1 = forward, -1 = backward

    void Update()
    {
        if (waypoints.Length < 2) return;

        // Move towards current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // If reached current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.01f)
        {
            if (pingPong)
            {
                if (currentWaypointIndex == waypoints.Length - 1)
                    direction = -1;
                else if (currentWaypointIndex == 0)
                    direction = 1;

                currentWaypointIndex += direction;
            }
            else
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}
