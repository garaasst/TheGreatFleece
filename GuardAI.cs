using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour {

    [SerializeField]
    private List<Transform> waypoints;

    private NavMeshAgent agent;
    private Animator anim;
    private int waypointIndex = 0;
    private bool isIdle = false;

    private bool heardCoin = false;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>(); 
        ChangeDestination();
        
	}
	
	// Update is called once per frame
	void Update () {
		
        if (heardCoin)
        {
            CheckCoin();
        }
        else
        {
            CheckWaypoint();
        }

	}


    private void CheckWaypoint()
    {
        if (!heardCoin && !isIdle && agent.remainingDistance <= agent.stoppingDistance)
        {
           
           if ( waypoints[waypointIndex].tag == "IdleWaypoint")
            {
                isIdle = true;
                anim.SetBool("Walk", false);
                StartCoroutine(WaitBeforeMoving());
            }
            else 
            {
                UpdateWaypoint();
            }
        }
    }

    private void ChangeDestination()
    {
        if (!heardCoin)
        {
            if (waypoints[waypointIndex] != null)
            {
                if (waypoints.Count > 1)
                {
                    anim.SetBool("Walk", true);
                }
                Transform target = waypoints[waypointIndex];
                agent.SetDestination(target.position);
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(5f);
        if (!heardCoin)
        {
            isIdle = false;
            UpdateWaypoint();
        }
    }

    private void UpdateWaypoint()
    {
        if (!heardCoin)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Count)
            {
                waypointIndex = 0;
            }
            ChangeDestination();
        }
    }



    public void AlertToCoin(Vector3 coinPos)
    {
        heardCoin = true;
        agent.SetDestination(coinPos);
        isIdle = false;
        anim.SetBool("Walk", true);
        
    }


    private void CheckCoin()
    {
        if (!isIdle && agent.remainingDistance <= agent.stoppingDistance)
        {
            isIdle = true;
            anim.SetBool("Walk", false);
            StartCoroutine(WaitAtCoin());
        }
    }

    private IEnumerator WaitAtCoin()
    {
        yield return new WaitForSeconds(5f);
        isIdle = false;
        heardCoin = false;
        ChangeDestination();
    }

}
