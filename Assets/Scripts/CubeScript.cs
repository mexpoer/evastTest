using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Transform[] waypoints;
    [SerializeField] public float speed = 5f;
    private int _currentWaypointIndex = 0;

    [SerializeField] private float waitTime = 2f;
    //private bool isWaiting = false;

    IEnumerator Move()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypointIndex].position,
                speed * Time.deltaTime);
            if (transform.position == waypoints[_currentWaypointIndex].position)
            {
                yield return new WaitForSeconds(waitTime);
                _currentWaypointIndex++;
                if (_currentWaypointIndex >= waypoints.Length)
                {
                    _currentWaypointIndex = 0;
                }
            }

            yield return null;
        }
    }

    void Start()
    {
        transform.position = waypoints[_currentWaypointIndex].position;
        StartCoroutine(Move());
    }
    
/* void Update()
{
    if (isWaiting)
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0f)
        {
            waitTime = 2f;
            isWaiting = false;

        }
    }
    else
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypointIndex].position,
            speed * Time.deltaTime);
        if (transform.position == waypoints[_currentWaypointIndex].position)
        {
            _currentWaypointIndex++;
            isWaiting = true;

            if (_currentWaypointIndex >= waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }
    }


*/
}




