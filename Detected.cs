using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detected : MonoBehaviour {

    [SerializeField]
    private GameObject cutscene;

    [SerializeField]
    private bool isCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isCamera)
            {
                MeshRenderer render = GetComponent<MeshRenderer>();
                Color color = new Color(0.6f, 0.1f, 0.1f, 0.3f);
                render.material.SetColor("_TintColor", color);
                Animator anim = GetComponentInParent<Animator>();
                anim.enabled = false;
                StartCoroutine(FreezeCam());
            }
            else
            {
                cutscene.SetActive(true);
            }
            
        }
    }

    IEnumerator FreezeCam()
    {
        yield return new WaitForSeconds(1f);
        cutscene.SetActive(true);
    }
}
