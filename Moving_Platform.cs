using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] way_Point;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if (Vector2.Distance(way_Point[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= way_Point.Length) 
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, way_Point[currentWaypointIndex].transform.position,Time.deltaTime * speed);
    }
}
