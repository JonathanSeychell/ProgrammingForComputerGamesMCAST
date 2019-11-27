using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();   
    }
    private void EnemyMovement()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].transform.position;
            targetPosition.z = 0f;

            float movementPerFrame = moveSpeed *  Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,targetPosition, movementPerFrame);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
