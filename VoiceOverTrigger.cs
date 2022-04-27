using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour {

    [SerializeField]
    private AudioClip voiceover;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.tag == "Player")
        {
            hasPlayed = true;
            AudioManager.Instance.PlayVoiceOver(voiceover);
        }
    }
}
