using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent nMa;
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    

    public Transform target;

    void Start()
    {
        nMa = GetComponent<NavMeshAgent>();
        wayPoint = GameObject.Find("Player");
    }

    void Update()
    {
        /*
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);

        
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        */

        nMa.SetDestination(wayPoint.transform.position);

        transform.LookAt(target);
    }
}
