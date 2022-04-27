using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggers : MonoBehaviour {

    [SerializeField]
    private GameObject triggerCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = triggerCamera.transform.position;
            Camera.main.transform.rotation = triggerCamera.transform.rotation;

        }
    }
}
