using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingGuardCutscene : MonoBehaviour {

    [SerializeField]
    private GameObject cutscene;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.HasCard = true;
            cutscene.SetActive(true);
        }
    }
}
