using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    NavMeshAgent agent;
    Animator anim;

    [SerializeField]
    private Transform coinPrefab;

    [SerializeField]
    private AudioClip coinSoundEffect;

    private bool canDoCoinToss = true;

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
         agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetBool("Walk", false);
        }
        if ( Input.GetMouseButtonDown(0) )
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if ( Physics.Raycast(rayOrigin, out hitInfo) )
            {
                agent.SetDestination(hitInfo.point);
                anim.SetBool("Walk", true);
            }
        }

        if (canDoCoinToss && Input.GetMouseButton(1))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                anim.SetTrigger("Throw");
                canDoCoinToss = false;
                StartCoroutine(WaitForCoinToss());
                Instantiate(coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSoundEffect, Camera.main.transform.position);
                SendAIToCoinSpot(hitInfo.point);

            }

        }
        
	}

    IEnumerator WaitForCoinToss()
    {
        yield return new WaitForSeconds(3f);
        canDoCoinToss = true;
    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach ( var guard in guards)
        {
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            currentGuard.AlertToCoin(coinPos);
        }
    }
}
