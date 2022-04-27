using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCutscene : MonoBehaviour {

    [SerializeField]
    private GameObject cutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.HasCard && other.tag == "Player")
        {
            cutscene.SetActive(true);
        }
    }
}
